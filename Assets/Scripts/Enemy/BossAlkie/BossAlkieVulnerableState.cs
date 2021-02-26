using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlkieVulnerableState : StateMachineBehaviour
{
    Rigidbody2D rb;
    Collider2D vulnerableCol;
    GameObject player;
    Hurtbox hurtbox;

    private float vulnerableDuration;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        rb = GameObject.Find("Boss").GetComponent<Rigidbody2D>();

        vulnerableCol = GameObject.Find("VulnerableCollider").GetComponent<PolygonCollider2D>();
        vulnerableCol.enabled = true;

        hurtbox = GameObject.FindObjectOfType<Hurtbox>();
        hurtbox.isHurt = false;

        vulnerableDuration = 5f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        vulnerableDuration -= Time.fixedDeltaTime;

        if(hurtbox.isHurt) {
            animator.SetTrigger("Invulnerable");
            rb.velocity = Vector3.zero;
        }
        else if (vulnerableDuration <= 0f) {
            animator.SetTrigger("Invulnerable");
        }
        rb.velocity = Vector3.zero;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        rb.velocity = Vector3.zero;
        animator.ResetTrigger("Invulnerable");
        vulnerableCol.enabled = false;
    }
}
