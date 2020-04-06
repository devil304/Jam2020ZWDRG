using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class OnTriggerExitDo : MonoBehaviour
{
    [SerializeField] UnityEvent DoUE;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "box")
        {
            DoUE.Invoke();
        }
    }
}
