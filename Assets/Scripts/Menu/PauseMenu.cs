using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;    
    public GameObject pauseMenuUI;

    private GameObject player;

    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) { // execute upon pressing esc key
            if(gameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() { 
        pauseMenuUI.SetActive(false);   // disable pause menu
        Time.timeScale = 1f;    // resumes all time based movements and calculations
        gameIsPaused = false;

        player.GetComponent<PlayerMovement>().enabled = true;   // enable movement script

        if(PlayerPrefs.GetInt("currentScene") == 2) {
            player.GetComponent<PlayerShoot>().enabled = true;
        }
    }

    void Pause() {
        pauseMenuUI.SetActive(true);    // enable pause menu
        Time.timeScale = 0f;    // all time based movements and calculations stops
        gameIsPaused = true;
        
        player.GetComponent<PlayerMovement>().enabled = false;  // disable movement script
        player.GetComponent<PlayerShoot>().enabled = false;
    }

    public void LoadMenu() {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
