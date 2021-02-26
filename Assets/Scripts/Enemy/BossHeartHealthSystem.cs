using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHeartHealthSystem : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private GameObject playerUI;
    private GameObject bossUI;

    private AudioManager audioManager;

    private bool played = false;

    void Start() {
        playerUI = GameObject.Find("PlayerCanvas");
        bossUI = GameObject.Find("BossCanvas");

        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        health = Mathf.Min(health, numOfHearts);

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
        
        if (health <= 0) {
            playerUI.SetActive(false);
            bossUI.SetActive(false);

            Destroy(gameObject);
            
            audioManager.Stop("BossBGM");

            if(!played) {
                audioManager.Stop("BossDeath");
                played = true;
            }
        }
    }

    public void Hurt() {
        health -= 1;
    }
}
