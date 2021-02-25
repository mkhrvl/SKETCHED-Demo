using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    HeartHealthSystem health;
    
    public GameObject deathMenuUI;

    void Start() {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<HeartHealthSystem>();
    }

    void Update() {
        if(health.health <= 0) {
            deathMenuUI.SetActive(true);
        }
    }

    public void RetryGame() {
        SceneManager.LoadScene(PlayerPrefs.GetInt("checkPoint"));
    }

    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
