using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "MainCamera" && collider.gameObject.tag != "Enemy" && collider.gameObject.tag != "Ammo") {
            Destroy(gameObject);
        }
    }
}
