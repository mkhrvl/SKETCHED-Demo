using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceUp : MonoBehaviour
{
    public Animator animator;

    void Start() {
        animator.SetFloat("LastVertical", 1f); // player start the level facing up
    }
}
