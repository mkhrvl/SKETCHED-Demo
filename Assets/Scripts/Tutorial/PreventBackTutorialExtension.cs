using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventBackTutorialExtension : MonoBehaviour
{
    public Collider2D col;

    void Update() {
        if(PlayerPrefs.GetInt("tutorialComplete") == 1) {
            col.isTrigger = false;
        }
        
    }
}
