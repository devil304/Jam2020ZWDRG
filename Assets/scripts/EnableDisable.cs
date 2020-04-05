using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    [SerializeField] GameObject Enable, Disable;
    // Start is called before the first frame update
    public void DoTheJob(float Delay){
        StartCoroutine(DoTheJobD(Delay));
    }

    IEnumerator DoTheJobD(float Delay){
        yield return new WaitForSeconds(Delay);
        Enable?.SetActive(true);
        Disable?.SetActive(false);
    }
}
