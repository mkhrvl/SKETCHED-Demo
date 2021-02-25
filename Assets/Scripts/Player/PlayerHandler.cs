using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerHandler : MonoBehaviour
{
    GameObject player;

    public CinemachineVirtualCamera vcam;

    private int currentScene;
    private int currentLevel;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");   

        currentScene = SceneManager.GetActiveScene().buildIndex;
        currentLevel = PlayerPrefs.GetInt("currentLevel");  
        
        if(PlayerPrefs.GetInt("didSaved") == 1 && currentScene != currentLevel) {
            Load();
        }
    }

    public void Save() {
        PlayerPrefs.SetFloat("playerPosX", player.transform.position.x);
        PlayerPrefs.SetFloat("playerPosY", player.transform.position.y);
        PlayerPrefs.SetInt("didSaved", 1);

        Debug.Log("Saved");
    }

    public void Load() {
        float playerPosX = PlayerPrefs.GetFloat("playerPosX");
        float playerPosY = PlayerPrefs.GetFloat("playerPosY");
        player.transform.position = new Vector3(playerPosX, playerPosY - 1);
        PlayerPrefs.SetInt("didSaved", 0);
        vcam.Follow = player.transform;

        Debug.Log("Loaded");
    }
}
