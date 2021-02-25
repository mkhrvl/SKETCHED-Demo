using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;

    public void OpenDoor() {
        if(!isOpen) {
            isOpen = true;
            animator.SetBool("isOpen", isOpen); // triggers condition to transition from close to open
        }
    }

    public void NextScene() { 
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loads next scene
    }
}
