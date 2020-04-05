using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class stairs : MonoBehaviour
{
    SonMovement sm;
    MotherMovement mm;
    [SerializeField] float waitTime;
    [SerializeField] UnityEvent finished;
    InteractionObject io;
    private void Start()
    {
        io = GetComponent<InteractionObject>();
        sm = FindObjectOfType<SonMovement>();
        mm = FindObjectOfType<MotherMovement>();
    }
    // Start is called before the first frame update
    public void moveStairs(Transform target)
    {
        io.interPlayer.SendMessage("fadeOut");
        StartCoroutine(move(target));
    }

    IEnumerator move(Transform target)
    {
        yield return new WaitForSeconds(waitTime);
        io.interPlayer.position = target.position;
        io.interPlayer.SendMessage("fadeIn");
        yield return new WaitForSeconds(waitTime);
        finished.Invoke();
    }
}
