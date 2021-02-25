using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestrictionBack : MonoBehaviour
{
    public Collider2D col;

    void Start() {
        if(PlayerPrefs.GetInt("tutorialComplete") == 1) {
            col.isTrigger = false;
        }
    }

}
