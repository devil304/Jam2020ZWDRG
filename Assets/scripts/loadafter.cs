using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadafter : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ls());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ls()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(name);
    }
}
