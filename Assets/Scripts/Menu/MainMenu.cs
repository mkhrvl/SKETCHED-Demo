using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button contBtn;

    void Start() {
        if(PlayerPrefs.GetInt("checkPoint") > 0) {
            contBtn.interactable = true;
        }
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.DeleteKey("playerPosX");
        PlayerPrefs.DeleteKey("playerPosY");
        PlayerPrefs.DeleteKey("didSaved");
        PlayerPrefs.DeleteKey("currentLevel");
        PlayerPrefs.DeleteKey("tutorialComplete");
        PlayerPrefs.DeleteKey("checkPoint");
        PlayerPrefs.DeleteKey("EnteredScene");
    }

    public void ContinueGame() {
        SceneManager.LoadScene(PlayerPrefs.GetInt("checkPoint"));
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
