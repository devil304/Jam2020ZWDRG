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
    // Start is called before the first frame update
    private void Awake()
    {
        sm = FindObjectOfType<SonMovement>();
        mm = FindObjectOfType<MotherMovement>();
    }

    public void block()
    {
        switch (ed)
        {
            case enableDisable.Enable:
                sm.enabled = true;
                mm.enabled = true;
                break;
            case enableDisable.Disable:
                sm.enabled = false;
                mm.enabled = false;
                break;
        }
    }
}
