using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceedLevel : MonoBehaviour
{
    Collider2D col;
    BossHeartHealthSystem bossHealth;

    void Start() {
        bossHealth = GameObject.Find("Boss").GetComponent<BossHeartHealthSystem>();
        col = GameObject.Find("LevelBoundariesForward").GetComponent<BoxCollider2D>();
    }

    void Update() {
        if(bossHealth.health == 0) {
            col.enabled = false;
        }
    }
}
