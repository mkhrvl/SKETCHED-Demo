using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartHealthSystem : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool invincible = false;

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

        // if (health == 0) {
        //     SceneManager.LoadScene(PlayerPrefs.GetInt("checkPoint")); 
        // }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(!invincible) {
            if(col.gameObject.tag == "Enemy") {
                health -= 1;
                invincible = true;

                Invoke("resetInvulnerability", 2);
            }
        }
        // else if(collision.gameObject.tag == "Potion") {
        //     health += 1;
        // }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(!invincible) {
            if(col.gameObject.tag == "Enemy") {
                health -= 1;
                invincible = true;

                Invoke("resetInvulnerability", 2);
            }
        }
        // else if(collider.gameObject.tag == "Potion") {
        //     health += 1;
        // }
    }

    void resetInvulnerability() {
        invincible = false;
    }
}
