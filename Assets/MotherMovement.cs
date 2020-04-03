using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MotherMovement : MonoBehaviour { 

    [SerializeField] float speed = 3;
    Rigidbody2D myRB2D;
    SpriteRenderer mySR;
    BoxCollider2D myBC;
    Vector2 InputValue;
    public bool isCrouching = false;
    Animator myAnimator;
    // Start is called before the first frame update
    void Start() {
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
        }
    }

    public void Crouch(CallbackContext cc) {
        if(cc.ReadValue<float>() == 1.0f && !isCrouching) {
            isCrouching = true;
            myBC.offset = new Vector2(myBC.offset.x, myBC.offset.y * 2);
            myBC.size = new Vector2(myBC.size.x, myBC.size.y / 2);

        } else if (cc.ReadValue<float>() == 0.0f && isCrouching) {
            isCrouching = false;
            myBC.offset = new Vector2(myBC.offset.x, myBC.offset.y / 2);
            myBC.size = new Vector2(myBC.size.x, myBC.size.y * 2);

        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(InputValue != Vector2.zero) {
            myRB2D.MovePosition((Vector2)transform.position + InputValue * Time.fixedDeltaTime);
        }
    }
}
