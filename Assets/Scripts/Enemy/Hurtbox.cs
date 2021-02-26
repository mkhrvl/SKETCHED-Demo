using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public BossHeartHealthSystem health;

    public bool isHurt;

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ammo") {
            health.Hurt();
            isHurt = true;
            FindObjectOfType<AudioManager>().Play("EnemyHurt");
        }
    }
}
