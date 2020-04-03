using UnityEngine;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    //[SerializeField] Volume v;
    [SerializeField] float speed = 10, jumpSpeed = 1;
    Rigidbody2D myRB2D;
    SpriteRenderer mySR;
    BoxCollider2D myBX;
    //ColorAdjustments tmp;
    float InputValue;
    bool grounded = false, Move = false;
    private void Start()
    {
        myBX = GetComponent<BoxCollider2D>();
        mySR = GetComponent<SpriteRenderer>();
        //v.profile.TryGet<ColorAdjustments>(out tmp);
        myRB2D = GetComponent<Rigidbody2D>();
    }
    public void move(CallbackContext cc)
    {
        if (!Move)
            Move = true;
        InputValue = cc.ReadValue<float>();
        if (InputValue > 0 && !mySR.flipX)
        {
            myBX.offset = new Vector2(-myBX.offset.x, myBX.offset.y);
            mySR.flipX = true;
        }
        else if (InputValue < 0 && mySR.flipX)
        {
            myBX.offset = new Vector2(-myBX.offset.x, myBX.offset.y);
            mySR.flipX = false;
        }
    }

    public void Jump(CallbackContext cc)
    {
        if(cc.ReadValue<float>() !=0 && grounded)
            myRB2D.AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Move && grounded)
        {
            myRB2D.velocity = (new Vector2(InputValue, myRB2D.velocity.y) * speed * Time.deltaTime);
            if (InputValue == 0)
                Move = false;
        }
        /*if (tmp)
        {
            tmp.saturation.value += Time.deltaTime * 20;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = false;
    }
}
