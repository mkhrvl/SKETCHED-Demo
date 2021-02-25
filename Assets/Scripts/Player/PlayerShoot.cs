using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bullet;

    public Rigidbody2D rb;

    public float bulletForce = 25f;
    public float receiveSpeed = 8f;
    public int ammoAmount = 1;

    private void Update() {
        // shoot when left mouse button is up (this is to take account of shooting upon releasing left mousebutton)
        if (Input.GetMouseButtonUp(0) && !playerMovement.isRolling && ammoAmount == 1) {
            Shoot();
        }

        // retrieve ammo after colliding with an object with holding right mouse button
        if (Input.GetMouseButton(1) && !playerMovement.isRolling && ammoAmount == 0 && bullet.GetComponent<ProjectileCollision>().hasCollided) {
            rb.velocity = rb.velocity * 0f;
            Retrieve();
        }
    }

    // shoots projectile from firing point and reduces ammo count
    private void Shoot() {  
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        ammoAmount -= 1;
    }

    // instatiated bullet move towards player
    private void Retrieve() {   
        rb.position = Vector3.MoveTowards(rb.position, transform.position, receiveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // removes ammo from ground upon collision with player and increases ammo count
        if(collision.gameObject.tag == "Ammo") {
            Destroy(collision.collider.gameObject);
            ammoAmount += 1;
        }
    }
}
