using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OczywiscieZeMaja : MonoBehaviour
{
    float volume = 1;
    // Start is called before the first frame update
    void Start()
    {
        OczywiscieZeMaja[] ozm = FindObjectsOfType<OczywiscieZeMaja>();
        if (ozm.Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += (x,y)=> { SVolume(); };
    }
    public void ValCh(Single s)
    {
        volume = s;
        SVolume();
    }
    private void SVolume()
    {
        AudioSource[] dlaczego = FindObjectsOfType<AudioSource>();
        foreach (AudioSource AS in dlaczego)
        {
            AS.volume = volume * AS.GetComponent<SoundVolCTRL>().startVol;
        }
    }
}
