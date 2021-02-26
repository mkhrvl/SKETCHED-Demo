using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    private int currentScene;
    private AudioManager audioManager;

    void Start() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        audioManager = FindObjectOfType<AudioManager>();
        
        switch(currentScene) {
            case 0:
                audioManager.Play("MenuBGM");
                break;
            case 1:
                PlayMusic("ExploreBGM");
                break;
            case 5:
                PlayMusic("BossBGM");
                break;
            case 6:
                PlayMusic("ExploreBGM");
                break;
            case 7:
                PlayMusic("BossBGM");
                break;
            case 8:
                PlayMusic("ExploreBGM");
                break;
            case 9:
                PlayMusic("MenuBGM");
                break;
        }
    }

    public void ButtonPressed() {
        audioManager.Play("ButtonPressed");
    }

    public void PlayMusic(string BGM) {
        audioManager.Stop("MenuBGM");
        audioManager.Stop("ExploreBGM");
        audioManager.Stop("BossBGM");

        audioManager.Play(BGM);
    }
}
