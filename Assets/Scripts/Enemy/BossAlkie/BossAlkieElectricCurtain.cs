using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlkieElectricCurtain : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    public GameObject bullet;

    public Rigidbody2D rb;

    private float bulletForce;
    private float attackInterval;
    private float resetInterval;

    private float previousNum = 0f;
    private float currentNum;

    void Start() {
        bulletForce = 3f;
        attackInterval = 1f;

        resetInterval = attackInterval;
    }

    void FixedUpdate() {
        attackInterval -= Time.fixedDeltaTime; 

        if(attackInterval <= 0f) {    // executes command after set interval
             attackInterval = resetInterval;

             RandomShoot();

             FindObjectOfType<AudioManager>().Play("EnemyShoot");
        }
    }

    private void RandomShoot(){
        while(true){
            currentNum = Random.Range(1,5);
            if(currentNum != previousNum) {
                previousNum = currentNum;
                break; 
            }
        }

        switch(currentNum) {
            case 1:
                ShootMiddle();
                break;
            case 2:
                ShootSides();
                break;
            case 3:
                ShootLeft();
                break;
            case 4:
                ShootRight();
                break;
        }
    }

    private void ShootSides() {
        for(float i = 5.5f; i <= 11.5f; i += 1.5f) {
            CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + i, firePoint.position.y, firePoint.position.z));
        }
        for(float i = 6.5f; i <= 12.5f; i += 1.5f) {
            CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - i, firePoint.position.y, firePoint.position.z));
        }
    }

    private void ShootMiddle() {
        for(float i = 0f; i <= 3f; i += 1.5f) {
            CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + i, firePoint.position.y, firePoint.position.z));
        }
        for(float i = 1.5f; i <= 4.5f; i += 1.5f) {
            CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - i, firePoint.position.y, firePoint.position.z));
        }
    }

    private void ShootRight(){
        for(float i = 0f; i <= 13f; i += 1.5f) {
            CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + i, firePoint.position.y, firePoint.position.z));
        }
        // for(float i = 1.5f; i <= 4.5f; i += 1.5f) {
        //     CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - i, firePoint.position.y, firePoint.position.z));
        // }
    }

    private void ShootLeft(){
        // for(float i = 1f; i <= 4f; i += 1.5f) {
        //     CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + i, firePoint.position.y, firePoint.position.z));
        // }
        for(float i = 0.5f; i <= 12.5f; i += 1.5f) {
            CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - i, firePoint.position.y, firePoint.position.z));
        }
    }

    private void CreateBullet(Vector3 offsetRotation, Vector3 newPosition) {
        firePoint.rotation = Quaternion.Euler(offsetRotation);      // changes rotation of firing point

        bullet = Instantiate(bulletPrefab, newPosition, firePoint.rotation);     // spawn bullet

        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);   // bullet speed calculation
    }
}
