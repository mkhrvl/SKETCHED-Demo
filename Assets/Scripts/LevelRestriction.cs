using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestriction : MonoBehaviour
{
    public Collider2D coll;

    void Start() {
        if(PlayerPrefs.GetInt("tutorialComplete") == 1) {
            coll.isTrigger = true;
        }
    }
}
