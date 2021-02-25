using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGhostShowerAttack : StateMachineBehaviour
{
    Rigidbody2D rb;
    GameObject shoot;

    private float attackDuration;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        shoot = GameObject.Find("Boss");
        shoot.GetComponent<ShowerAttack>().enabled = true;

        attackDuration = 5f;       
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        attackDuration -= Time.deltaTime;

        if(attackDuration <= 0) {
            animator.SetTrigger("Vulnerable");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        shoot.GetComponent<ShowerAttack>().enabled = false;
        animator.ResetTrigger("Vulnerable");
    }
}
