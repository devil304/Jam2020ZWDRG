using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    SonMovement sm;
    MotherMovement mm;
    private void Start() {
        Init(SceneManager.GetActiveScene(),SceneManager.GetActiveScene());
        SceneManager.activeSceneChanged += Init;
    }

    private void Init(Scene current, Scene next)
    {
        sm = FindObjectOfType<SonMovement>();
        mm = FindObjectOfType<MotherMovement>();
        sm?.fadeIn();
        mm?.fadeIn();
    }

    public void LoadScene(string name){
        StartCoroutine(LSA(name));
    }

    IEnumerator LSA(string name){
        sm?.fadeOut();
        mm?.fadeOut();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
        asyncOperation.allowSceneActivation = false;
        yield return new WaitForSeconds(sm?sm.fadeSpeed:0);
        asyncOperation.allowSceneActivation = true;
    }
}
