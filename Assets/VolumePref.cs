using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumePref : MonoBehaviour
{
    public Slider volume;

    void Awake() {
        volume.value = PlayerPrefs.GetFloat("Volume");
    }

    void Update() {
        PlayerPrefs.SetFloat("Volume", volume.value);
    }
}
