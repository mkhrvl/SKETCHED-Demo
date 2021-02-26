using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    public Animator animator;

    public Collider2D col;

    public bool haveEntered = false;

    void Update() {
        if(haveEntered) {
            col.isTrigger = false;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            animator.SetTrigger("StartFight");
            haveEntered = true;
        }
    }
}
