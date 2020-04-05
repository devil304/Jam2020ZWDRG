﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {
    [SerializeField] GameObject Light;

    public void ToggleLight() {
        Light.SetActive(!Light.gameObject.activeInHierarchy);
    }

}
