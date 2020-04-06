using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PushPull : MonoBehaviour
{
    SonMovement sm;
    MotherMovement mm;
    Rigidbody2D myRB;
    Actor lastActor;
    PolygonCollider2D myPC2D;
    private void Awake()
    {
        myPC2D = GetComponent<PolygonCollider2D>();
        myPC2D.enabled = false;
        myRB = GetComponent<Rigidbody2D>();
        sm = FindObjectOfType<SonMovement>();
        mm = FindObjectOfType<MotherMovement>();
    }
    public void pushPull(Actor type)
    {
        if (type == Actor.Both)
            type = lastActor;
        else
            lastActor = type;
        switch (type)
            {
                case Actor.SON:
                    if (!sm.PushPullB)
                    {
                        myPC2D.enabled = true;  
                        sm.PushPullB = true;
                        sm.box = myRB;
                    }
                    else
                    {
                    myPC2D.enabled = false;
                    sm.PushPullB = false;
                        sm.box = null;
                        sm.myAnim.SetInteger("PushPull", 0);
                    }
                    break;
                case Actor.MOTHER:
                    if (!mm.PushPullB)
                    {
                    myPC2D.enabled = true;
                    mm.PushPullB = true;
                        mm.box = myRB;
                    }
                    else
                    {
                    myPC2D.enabled = false;
                    mm.PushPullB = false;
                        mm.box = null;
                        mm.myAnimator.SetInteger("PushPull", 0);
                    }
                    break;
            }
    }
}
