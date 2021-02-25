using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceLeft : MonoBehaviour
{
    public Animator animator;

    void Start() {
        animator.SetFloat("LastHorizontal", -1f); // player start the level facing left
    }
}
