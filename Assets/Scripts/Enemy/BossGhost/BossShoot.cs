﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    public GameObject bullet;

    public Rigidbody2D rb;

    private float bulletForce;
    private float attackInterval;
    private float resetInterval;

    void Start() {
        bulletForce = 6f;
        attackInterval = 0.5f;

        resetInterval = attackInterval;
    }

    void FixedUpdate() {
        attackInterval -= Time.fixedDeltaTime; 

        if(attackInterval < 0f) {    // executes command after set interval
             Shoot();
             attackInterval = resetInterval;

             FindObjectOfType<AudioManager>().Play("EnemyShoot");
        }
    }

    private void Shoot() {  
        // create bullet with different angles
        CreateBullet(new Vector3(0f, 0f, -180f));

        CreateBullet(new Vector3(0f, 0f, -180f - 20f));
        CreateBullet(new Vector3(0f, 0f, -180f - 40f));
        CreateBullet(new Vector3(0f, 0f, -180f - 60f));
        CreateBullet(new Vector3(0f, 0f, -180f - 80f));
        CreateBullet(new Vector3(0f, 0f, -180f - 100f));

        CreateBullet(new Vector3(0f, 0f, -180f + 20f));
        CreateBullet(new Vector3(0f, 0f, -180f + 40f));
        CreateBullet(new Vector3(0f, 0f, -180f + 60f));
        CreateBullet(new Vector3(0f, 0f, -180f + 80f));
        CreateBullet(new Vector3(0f, 0f, -180f + 100f));
    }

    private void CreateBullet(Vector3 offsetRotation) {
        firePoint.rotation = Quaternion.Euler(offsetRotation);      // changes rotation of firing point

        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);     // spawn bullet

        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);   // bullet speed calculation
    }
}
