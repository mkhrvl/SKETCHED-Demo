using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerAttack : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    public GameObject bullet;

    public Rigidbody2D rb;

    public float bulletForce = 5f;
    public float attackInterval = 1f;
    private float resetInterval;

    private bool isEven = true;

    void Start() {
        resetInterval = attackInterval;
    }

    void Update() {
        attackInterval -= Time.fixedDeltaTime; 

        if(attackInterval <= 0f && isEven) {    // executes command after set interval
             ShootEven();
             attackInterval = resetInterval;
             isEven = false;
        }
        else if(attackInterval <= 0f && isEven == false) {
            ShootOdd();
            attackInterval = resetInterval;
            isEven = true;
        }
    }

    private void ShootEven() {  
        // create bullet with different angles
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z));

        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 1.8f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 3.6f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 5.4f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 7.2f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 9f, firePoint.position.y, firePoint.position.z));

        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 1.8f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 3.6f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 5.4f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 7.2f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 9f, firePoint.position.y, firePoint.position.z));
    }

    private void ShootOdd() {
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 0.9f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 2.7f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 4.5f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 6.3f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x + 8.1f, firePoint.position.y, firePoint.position.z));

        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 0.9f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 2.7f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 4.5f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 6.3f, firePoint.position.y, firePoint.position.z));
        CreateBullet(new Vector3(0f, 0f, -180f), new Vector3(firePoint.position.x - 8.1f, firePoint.position.y, firePoint.position.z));
    }

    private void CreateBullet(Vector3 offsetRotation, Vector3 newPosition) {
        firePoint.rotation = Quaternion.Euler(offsetRotation);      // changes rotation of firing point

        bullet = Instantiate(bulletPrefab, newPosition, firePoint.rotation);     // spawn bullet

        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);   // bullet speed calculation
    }
}
