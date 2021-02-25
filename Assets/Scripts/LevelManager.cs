using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameObject player;

    PlayerHandler playerHandler;

    private int currentScene;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHandler = FindObjectOfType<PlayerHandler>();

        currentScene = SceneManager.GetActiveScene().buildIndex;

        if(PlayerPrefs.GetInt("tutorialComplete") == 1) {
            player.GetComponent<PlayerAimWeapon>().enabled = true;
            player.GetComponent<PlayerShoot>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        switch(currentScene) {
            case 2: // Tutorial
                if(col.CompareTag("Enemy")) {
                    SceneManager.LoadScene(currentScene);
                }
                else if(col.CompareTag("EnterRoom")) {
                    playerHandler.Save();
                    LoadNextScene();
                }
                else if (col.CompareTag("Transition")) {
                    SceneManager.LoadScene(currentScene + 2);
                }
                break;
            case 3: // Tutorial Extension
                if(col.CompareTag("ExitRoom")) {
                    PlayerPrefs.SetInt("tutorialComplete", 1);
                    SceneManager.LoadScene(currentScene - 1);
                }
                break;
            case 4: // Hallway 1
                if(col.CompareTag("Transition")) {
                    LoadNextScene();
                }
                break;
            case 5: // Boss Fight 1
                if(col.CompareTag("Transition")) {
                    LoadNextScene();
                }
                break;
            case 6: // Hallway 2
                if(col.CompareTag("Transition")) {
                    LoadNextScene();
                }
                break;
            case 7: // Boss Fight 2
                if(col.CompareTag("Transition")) {
                    LoadNextScene();
                }
                break;
            case 8: // Hallway 3
                if(col.CompareTag("Transition")) {
                    LoadNextScene();
                }
                break;
        }

        if(col.CompareTag("Checkpoint")) {
            playerHandler.Save();
            PlayerPrefs.SetInt("checkPoint", currentScene);
        }
    }

    void LoadNextScene() {
        SceneManager.LoadScene(currentScene + 1);
        PlayerPrefs.SetInt("currentLevel", currentScene + 1);
    }
}
