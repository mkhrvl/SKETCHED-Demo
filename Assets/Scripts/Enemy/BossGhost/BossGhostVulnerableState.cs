using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGhostVulnerableState : StateMachineBehaviour
{
    Rigidbody2D rb;
    Collider2D vulnerableCol;
    GameObject player;
    Hurtbox hurtbox;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        rb = GameObject.Find("Boss").GetComponent<Rigidbody2D>();

        vulnerableCol = GameObject.Find("VulnerableCollider").GetComponent<PolygonCollider2D>();
        vulnerableCol.enabled = true;

        hurtbox = GameObject.FindObjectOfType<Hurtbox>();
        hurtbox.isHurt = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(hurtbox.isHurt) {
            animator.SetTrigger("Invulnerable");
        }
        rb.velocity = Vector3.zero;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.ResetTrigger("Invulnerable");
        vulnerableCol.enabled = false;
    }
}
