using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public bool hasCollided;

    void Start() {
        hasCollided = false;
    }

    void OnCollisionEnter2D(Collision2D col) {
        hasCollided = true;
    }

    void OnCollisionExit2D(Collision2D col) {
        hasCollided = true;
    }

    void OnTriggerEnter2D(Collider2D col) {
        hasCollided = true;
    }
}
