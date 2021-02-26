using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHealthSystem : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool invincible = false;
    private bool played = false;

    private AudioManager audioManager;

    void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update() {
        health = Mathf.Min(health, numOfHearts); // doesn't go over heart limit when healed

        for (int i = 0; i < hearts.Length; i++) {
            if(i < health) {
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts) {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }

        if(health <= 0) {           
            if(!played) {
                audioManager.Play("PlayerDeath");
                played = true;
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(!invincible) {
            if(col.gameObject.tag == "Enemy") {
                health -= 1;
                invincible = true;

                Invoke("resetInvulnerability", 1);

                audioManager.Play("PlayerHurt");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(!invincible) {
            if(col.gameObject.tag == "Enemy") {
                health -= 1;
                invincible = true;

                Invoke("resetInvulnerability", 1);

                audioManager.Play("PlayerHurt");
            }
        }
    }

    void resetInvulnerability() {
        invincible = false;
    }
}
