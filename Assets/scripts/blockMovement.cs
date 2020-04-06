using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum enableDisable {Enable,Disable }
public class blockMovement : MonoBehaviour
{
    SonMovement sm;
    MotherMovement mm;
    public enableDisable ed;
    [SerializeField] Actor typeA = Actor.Both;
    Actor LastActor;
    // Start is called before the first frame update
    private void Awake()
    {
        sm = FindObjectOfType<SonMovement>();
        mm = FindObjectOfType<MotherMovement>();
    }

    public void block(Actor type)
    {
        LastActor = type;
        switch (ed)
        {
            case enableDisable.Enable:
                    switch (type)
                    {
                        case Actor.SON:
                            sm.enabled = true;
                            break;
                        case Actor.MOTHER:
                            mm.enabled = true;
                            break;
                    }
                break;
            case enableDisable.Disable:
                    switch (type)
                    {
                        case Actor.SON:
                            sm.enabled = false;
                            break;
                        case Actor.MOTHER:
                            mm.enabled = false;
                            break;
                    }
                break;
        }
    }
    public void block()
    {
        switch (ed)
        {
            case enableDisable.Enable:
                if (typeA != Actor.Both)
                    switch (LastActor)
                    {
                        case Actor.SON:
                            sm.enabled = true;
                            break;
                        case Actor.MOTHER:
                            mm.enabled = true;
                            break;
                    }
                else
                {
                    sm.enabled = true;
                    mm.enabled = true;
                }
                break;
            case enableDisable.Disable:
                if (typeA != Actor.Both)
                    switch (LastActor)
                    {
                        case Actor.SON:
                            sm.enabled = false;
                            break;
                        case Actor.MOTHER:
                            mm.enabled = false;
                            break;
                    }
                else
                {
                    sm.enabled = false;
                    mm.enabled = false;
                }
                break;
        }
    }
}
