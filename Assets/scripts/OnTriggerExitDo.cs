using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class OnTriggerExitDo : MonoBehaviour
{
    bool enter = false;
    IEnumerator w8()
    {
        yield return new WaitForSeconds(0.5f);
        enter = true;
    }
    [SerializeField] UnityEvent DoUE;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "box" && enter)
        {
            DoUE.Invoke();
        }
    }
}
