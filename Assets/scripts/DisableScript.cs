using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScript : MonoBehaviour
{
    [SerializeField] Behaviour script;
    public void DS()
    {
        script.enabled = false;
    }
}
