﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTest : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    public GameObject bullet;

    public Rigidbody2D rb;

    private float bulletForce;
    private float attackInterval;

    private float resetInterval;

    void Start() { 
        bulletForce = 9f;
        attackInterval = 0.3f;

        resetInterval = attackInterval;
    }

    void FixedUpdate() {
        if(PlayerPrefs.GetInt("tutorialComplete") != 1) {
            
            attackInterval -= Time.fixedDeltaTime; 

            if(attackInterval < 0f) {   // executes command after set interval
                Shoot();
                attackInterval = resetInterval;

                FindObjectOfType<AudioManager>().Play("EnemyShoot");
            } 
        }
    }

    private void Shoot() {  
        CreateBullet(new Vector3(0f, 0f, -180f));
    }

    private void CreateBullet(Vector3 offsetRotation) {
        firePoint.rotation = Quaternion.Euler(offsetRotation);      // changes rotation of firing point

        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);     // spawn bullet

        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);   // bullet speed calculation
    }
}
