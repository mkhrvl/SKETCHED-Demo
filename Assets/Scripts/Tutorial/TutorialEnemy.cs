using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public Collider2D coll;
        
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ammo")) {
            Destroy(gameObject);

            coll.isTrigger = true;
        }
    }
}
