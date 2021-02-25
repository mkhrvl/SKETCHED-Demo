using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{

    public bool hasCollided;

    void Start()
    {
        hasCollided = false;
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        hasCollided = true;
    }
}
