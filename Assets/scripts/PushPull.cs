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
    private void Awake()
    {
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
                        sm.PushPullB = true;
                        sm.box = myRB;
                    }
                    else
                    {
                        sm.PushPullB = false;
                        sm.box = null;
                        sm.myAnim.SetInteger("PushPull", 0);
                    }
                    break;
                case Actor.MOTHER:
                    /*if (!mm.PushPullB)
                    {
                        mm.PushPullB = true;
                        mm.box = myRB;
                    }
                    else
                    {
                        mm.PushPullB = false;
                        mm.box = null;
                        mm.myAnim.SetFloat("PushPull",0f);
                    }*/
                    break;
            }
    }
}
