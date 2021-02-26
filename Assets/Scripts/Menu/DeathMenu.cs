using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    HeartHealthSystem health;
    
    public GameObject deathMenuUI;

    private AudioManager audioManager;

    void Start() {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<HeartHealthSystem>();

        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update() {
        if(health.health <= 0) {
            deathMenuUI.SetActive(true);
        }
    }

    public void RetryGame() {
        SceneManager.LoadScene(PlayerPrefs.GetInt("checkPoint"));
        audioManager.Play("Respawn");
        audioManager.Stop("BossBGM");
        audioManager.Play("ExploreBGM");
    }

    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
