using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpiderDance : MonoBehaviour
{
    [SerializeField]Animator son;
    [SerializeField] SonMovement sm;
    public UnityEvent endEv;
    public void SDStart()
    {
        sm.block = true;
        sm.enabled = false;
        son.SetBool("sd",true);
    }
     public void endEV()
    {
        sm.block = false;
        sm.enabled = true;
    }

}
