using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    void Awake() {
    
        if(PlayerPrefs.GetInt("SetVolume") != 1) {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetFloat("Volume", 0.5f);
            PlayerPrefs.SetInt("SetVolume", 1);
        }   
    }
}
