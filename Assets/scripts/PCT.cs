using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class PCT : MonoBehaviour
{
    public int Hp = 30;
    [SerializeField] private InputActionMap myMap;
    [SerializeField] private float dmgToDo = 0;
    [SerializeField] private RectTransform hp;
    [SerializeField] private bool block = false, blockpressed = false;
    [Range(0, 100)] [SerializeField] private int reduction = 0;
    private Rigidbody2D myrb;
    private BoxCollider2D myc;
    private Vector2 movevect = new Vector2(0, 0);
    private Animator myanim;
    //private shaderControl sc;
    private float mh = 0, ml = 0;
    private int maxHp;
    //private P1Scr p1st;
    public GameObject mygo;
    public SpriteRenderer mySr;
    public AudioSource myas;
    public AudioClip[] acs;

    [SerializeField] private float speed = 1;

    
    public void Setup(InputActionMap iam)
    {
        maxHp = Hp;
        setupmygo();
        //p1st = mygo.GetComponent<P1Scr>();
        myas = mygo.GetComponent<AudioSource>();
        //sc = mygo.GetComponent<shaderControl>();
        myMap = iam; 
        mySr = mygo.GetComponent<SpriteRenderer>();
        myrb = mygo.GetComponent<Rigidbody2D>();
        myc = mygo.GetComponent<BoxCollider2D>();
        myanim = mygo.GetComponent<Animator>();
        myMap.FindAction("Move").performed += cos;
        myMap.FindAction("Move").performed += (obj) =>
        {
            movevect = obj.ReadValue<Vector2>();
            if (movevect.x > 0 && !mySr.flipX)
            {
                myc.offset = new Vector2(-myc.offset.x, myc.offset.y);
                mySr.flipX = true;
            }
            else if (movevect.x < 0 && mySr.flipX)
            {
                myc.offset = new Vector2(-myc.offset.x, myc.offset.y);
                mySr.flipX = false;
            }
            if (myanim.GetInteger("chnage") == 0 && !blockpressed)
            {
                myanim.SetInteger("chnage", 1);
            }
        };

        myMap.FindAction("Move").canceled += (obj) =>
        {
            movevect = Vector2.zero;
            if (myanim.GetInteger("chnage") == 1 && !blockpressed)
            {
                myanim.SetInteger("chnage", 0);
            }
        };
        myMap.FindAction("Block").started += (obj) =>
        {
            blockpressed = true;
            myanim.SetInteger("chnage", 4);
        };
        myMap.FindAction("Block").canceled += (obj) =>
        {
            block = false;
            blockpressed = false;
            myanim.SetInteger("chnage", 0);
        };
        myMap.FindAction("BaseAtt").started += (obj) =>
        {
            if (UnityEngine.Random.Range(0, 100) > 84)
            {
                myas.PlayOneShot(acs[0]);
            }
            myanim.SetInteger("chnage", 2);
        };
        myMap.FindAction("SpecAtt").performed += (obj) =>
        {
            int tmp;
            Int32.TryParse(obj.ReadValueAsObject().ToString(), out tmp);
            if (tmp > 0)
            {
                /*if (p1st.ready)
                {
                    myas.PlayOneShot(acs[1]);
                }*/
                myanim.SetInteger("chnage", 3);
            }
            else
            {

            }
        };
        myMap.FindAction("Menu").performed += (obj) =>
        {
            SceneManager.LoadScene("MainMenu");
        };
    }

    private void cos(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    public void endofblock()
    {
        block = false;
    }
    public void startblock()
    {
        block = true;
    }
    abstract public void setupmygo();

    // Update is called once per frame
    virtual public void Update()
    {
        if (movevect != Vector2.zero)
        {
            myrb.MovePosition(myrb.position + (movevect * speed * Time.deltaTime));
        }
    }
    public void BaseAttack()
    {
        RaycastHit2D rh2d;
        rh2d = Physics2D.Raycast((Vector2)mygo.transform.position + ((mySr.flipX ? Vector2.right : Vector2.left) * 0.5f), mySr.flipX ? Vector2.right : Vector2.left, 1.8f);
        Debug.DrawRay((Vector2)mygo.transform.position + ((mySr.flipX ? Vector2.right : Vector2.left) * 0.5f), (mySr.flipX ? Vector2.right : Vector2.left) * 1.8f, Color.red, 2);
        if (rh2d)
        {
            rh2d.collider.gameObject.SendMessage("recieveDamage", dmgToDo);
        }
        rh2d = Physics2D.Raycast((Vector2)mygo.transform.position + ((mySr.flipX ? Vector2.right : Vector2.left) * 0.5f), (mySr.flipX ? Vector2.right : Vector2.left) + Vector2.up, 1.1f);
        Debug.DrawRay((Vector2)mygo.transform.position + ((mySr.flipX ? Vector2.right : Vector2.left) * 0.5f), ((mySr.flipX ? Vector2.right : Vector2.left) + Vector2.up) * 1.1f, Color.red, 2);
        if (rh2d)
        {
            rh2d.collider.gameObject.SendMessage("recieveDamage", dmgToDo);
        }
    }

    public void EndOfAttAnim()
    {
        mh = 0.75f;
        (myMap.devices.Value[0] as Gamepad).SetMotorSpeeds(ml, mh);
        if (movevect.x != 0)
        {
            myanim.SetInteger("chnage", 1);
        }
        else
        {
            myanim.SetInteger("chnage", 0);
        }
    }

    public void AttFinish()
    {
        mh = 0f;
        (myMap.devices.Value[0] as Gamepad).SetMotorSpeeds(ml, mh);
    }

    abstract public void Spec1Attack();
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(myc, other.collider);
        }
    }
    public void recieveDamage(int dmg)
    {
        dmg = (int)(block ? (float)dmg * (float)((float)reduction / 100f) : dmg);
        Hp -= dmg;
        hp.localScale = new Vector3((float)((float)Hp / (float)maxHp), hp.transform.localScale.y, hp.transform.localScale.z);
        //StartCoroutine(sc.damaged());
        StartCoroutine(damaged());
        if (Hp < 1)
        {
            myas.PlayOneShot(acs[2]);
            //sc.dissolved = true;
            Destroy(mygo, 1.5f);
            Destroy(this, 1f);
            Destroy(hp.transform.parent.transform.parent.transform.parent.gameObject);
        }
    }
    private void OnDestroy()
    {
        (myMap.devices.Value[0] as Gamepad).SetMotorSpeeds(0, 0);
        myMap.Disable();
    }

    public IEnumerator damaged()
    {
        ml = 0.65f;
        (myMap.devices.Value[0] as Gamepad).SetMotorSpeeds(ml, mh);
        yield return new WaitForSeconds(0.3f);
        ml = 0f;
        (myMap.devices.Value[0] as Gamepad).SetMotorSpeeds(ml, mh);
    }
}
