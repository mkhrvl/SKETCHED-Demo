using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseDoor : MonoBehaviour
{
    public Animator animator;

    private float delay = 0.1f;

    private bool played = false;

    void Start() {
        animator.SetBool("isOpen", true);
    }

    void FixedUpdate() {
        delay -= Time.fixedDeltaTime;

        if(delay <= 0) {
            animator.SetBool("isOpen", false);

            if(!played && PlayerPrefs.GetInt("EnteredScene") == 0) {
                played = true;
                FindObjectOfType<AudioManager>().Play("DoorClose");
            }
        }
    }
}
