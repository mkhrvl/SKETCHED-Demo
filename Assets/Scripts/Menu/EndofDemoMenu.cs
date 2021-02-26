using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndofDemoMenu : MonoBehaviour
{
    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
        PlayerPrefs.DeleteKey("playerPosX");
        PlayerPrefs.DeleteKey("playerPosY");
        PlayerPrefs.DeleteKey("didSaved");
        PlayerPrefs.DeleteKey("currentLevel");
        PlayerPrefs.DeleteKey("tutorialComplete");
        PlayerPrefs.DeleteKey("checkPoint");
        PlayerPrefs.DeleteKey("EnteredScene");
    }
}
