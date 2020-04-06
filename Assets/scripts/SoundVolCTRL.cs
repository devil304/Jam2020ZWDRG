using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolCTRL : MonoBehaviour
{
    [HideInInspector] public float startVol;
    private void Awake()
    {
        startVol = GetComponent<AudioSource>().volume;
    }
}