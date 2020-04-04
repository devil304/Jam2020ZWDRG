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
    }

    public void LoadScene(string name){
        sm?.fadeOut();
        SceneManager.LoadScene(name);
    }
}
