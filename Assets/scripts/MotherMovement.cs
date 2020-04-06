using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MotherMovement : MonoBehaviour { 

    [SerializeField] float speed = 3, fadeSpeed = 1.5f;
    Rigidbody2D myRB2D;
    SpriteRenderer mySR;
    BoxCollider2D myBC;
    Vector2 InputValue;
    public bool isCrouching = false;
    private bool actionButtonClicked = false;
    public Animator myAnimator;
    public InteractionObject myIO;
    public bool PushPullB = false;
    public Rigidbody2D box;
    // Start is called before the first frame update
    void Awake() {
        myRB2D = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();
        myBC = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    public void Move(CallbackContext cc) {
        InputValue = new Vector2(cc.ReadValue<Vector2>().x * speed, 0);
        myAnimator.SetFloat("Speed", Mathf.Abs(cc.ReadValue<Vector2>().x));
        if (InputValue.x > 0 && mySR.flipX) {
            mySR.flipX = false;
            myBC.offset = new Vector2(-myBC.offset.x, myBC.offset.y);
        } else if (InputValue.x < 0 && !mySR.flipX) {
            mySR.flipX = true;
            myBC.offset = new Vector2(-myBC.offset.x, myBC.offset.y);
            if (!PushPullB)
                mySR.flipX = true;
        }
        if (PushPullB) {
            myAnimator.SetInteger("PushPull", (int)InputValue.x);
            mySR.flipX = true;
        }
    }


    public void Crouch(CallbackContext cc) {
        int boxColiderMultiplyer = 3;
        if(cc.ReadValue<float>() == 1.0f && !isCrouching) {
            isCrouching = true;
            myBC.offset = new Vector2(myBC.offset.x, myBC.offset.y / boxColiderMultiplyer);
            myBC.size = new Vector2(myBC.size.x, myBC.size.y / boxColiderMultiplyer);
            myAnimator.SetBool("IsCrouching", isCrouching);

        } else if (cc.ReadValue<float>() == 0.0f && isCrouching) {
            isCrouching = false;
            myBC.offset = new Vector2(myBC.offset.x, myBC.offset.y * boxColiderMultiplyer);
            myBC.size = new Vector2(myBC.size.x, myBC.size.y * boxColiderMultiplyer);
            myAnimator.SetBool("IsCrouching", isCrouching);
        }
    }

    public void MotherAction(CallbackContext cc) {
        if (cc.ReadValue<float>() == 1.0f && !actionButtonClicked) {
            actionButtonClicked = true;
            myIO?.OnPlayerAction(Actor.MOTHER);
        } else if (cc.ReadValue<float>() == 0.0f && actionButtonClicked) {
            actionButtonClicked = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(InputValue != Vector2.zero) {
            myRB2D.MovePosition((Vector2)transform.position + InputValue * Time.fixedDeltaTime);
            if (PushPullB) {
                box.MovePosition((Vector2)box.transform.position + new Vector2(InputValue.x, box.velocity.y) * Time.fixedDeltaTime);
            }
        }
    }
    
    public void SetInteractionObject(InteractionObject io) {
        myIO = io;
    }
    public void ClearInteractionObject(InteractionObject io) {
        if(io == myIO)
            myIO = null;
    }

    IEnumerator FadeTo (float aValue, float aTime) {
        float alpha = mySR.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            Color newColor = new Color (1, 1, 1, Mathf.Lerp (alpha, aValue, t));
            mySR.color = newColor;
            yield return null;
        }
    }

    public void fadeOut () {
        StartCoroutine (FadeTo (0, fadeSpeed));
    }

    public void fadeIn () {
        StartCoroutine (FadeTo (1, fadeSpeed));
    }
}
