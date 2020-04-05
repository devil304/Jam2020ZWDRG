using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent (typeof (Rigidbody2D))]
public class SonMovement : MonoBehaviour {
    [SerializeField] bool FadeOutIn = false;
    Animator myAnim;
    //[SerializeField] Volume v;
    [SerializeField] float speed = 10;
    public float fadeSpeed = 1.5f;
    Rigidbody2D myRB2D;
    SpriteRenderer mySR;
    BoxCollider2D myBX;

    InteractionObject myIO;
    //ColorAdjustments tmp;
    float InputValue;
    bool grounded = false, Move = false;
    private void Awake () {
        myAnim = GetComponent<Animator> ();
        myBX = GetComponent<BoxCollider2D> ();
        mySR = GetComponent<SpriteRenderer> ();
        //v.profile.TryGet<ColorAdjustments>(out tmp);
        myRB2D = GetComponent<Rigidbody2D> ();
        //StartCoroutine (FadeTo (0, fadeSpeed));
    }
    public void move (CallbackContext cc) {
        if (!Move)
            Move = true;
        InputValue = cc.ReadValue<float> ();
        if (InputValue < 0 && !mySR.flipX) {
            myBX.offset = new Vector2 (-myBX.offset.x, myBX.offset.y);
            mySR.flipX = true;
        } else if (InputValue > 0 && mySR.flipX) {
            myBX.offset = new Vector2 (-myBX.offset.x, myBX.offset.y);
            mySR.flipX = false;
        }
    }

    /*public void Jump (CallbackContext cc) {
        if (cc.ReadValue<float> () != 0 && grounded && !FadeOutIn)
            myRB2D.AddForce (Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }*/

    private void FixedUpdate () {
        if (Move && !FadeOutIn) {
            myRB2D.MovePosition ((Vector2) transform.position + new Vector2 (InputValue, myRB2D.velocity.y) * speed * Time.fixedDeltaTime);
            if (InputValue == 0) {
                Move = false;
                myAnim.SetBool ("Walk", false);
            } else {
                myAnim.SetBool ("Walk", true);
            }
        } else if (FadeOutIn && Move) {
            myRB2D.velocity = new Vector2 (0, 0);
            Move = false;
            myAnim.SetBool ("Walk", false);
        }
        Color newColor = new Color(1, 1, 1, 1);
        mySR.color = newColor;
        /*if (tmp)
        {
            tmp.saturation.value += Time.deltaTime * 20;
        }*/
    }

    IEnumerator FadeTo (float aValue, float aTime) {
        FadeOutIn = true;
        float alpha = mySR.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            Color newColor = new Color (1, 1, 1, Mathf.Lerp (alpha, aValue, t));
            mySR.color = newColor;
            yield return null;
        }
        FadeOutIn = false;
    }

    public void Action (CallbackContext cc) {
        if (cc.performed && myIO)
            myIO.OnPlayerAction (Actor.SON);
    }

    public void fadeOut () {
        StartCoroutine (FadeTo (0, fadeSpeed));
    }

    public void fadeIn () {
        StartCoroutine (FadeTo (1, fadeSpeed));
    }

    public void SetInteractionObject (InteractionObject io) {
        myIO = io;
    }
    public void ClearInteractionObject () {
        myIO = null;
    }
}