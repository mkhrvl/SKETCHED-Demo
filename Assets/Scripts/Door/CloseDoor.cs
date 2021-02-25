using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public Animator animator;

    private float delay = 0.1f;

    void Start() {
        animator.SetBool("isOpen", true);
    }

    void FixedUpdate() {
        delay -= Time.fixedDeltaTime;

        if(delay <= 0) {
            animator.SetBool("isOpen", false);
        }
    }
}
