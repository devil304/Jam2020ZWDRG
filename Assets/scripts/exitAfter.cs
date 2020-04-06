using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitAfter : MonoBehaviour
{
    [SerializeField] float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ls());
    }

    IEnumerator ls()
    {
        yield return new WaitForSeconds(time);
        Application.Quit();
    }
}
