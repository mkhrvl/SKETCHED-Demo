using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlkieInvulnerableState : StateMachineBehaviour
{
    GameObject shoot;

    private float attackDuration;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        shoot = GameObject.Find("Boss");        

        if (shoot.GetComponent<BossAlkieElectricCurtain>().enabled == false) {
            shoot.GetComponent<BossAlkieElectricCurtain>().enabled = true;
        }

        attackDuration = 40f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        attackDuration -= Time.fixedDeltaTime;

        if(attackDuration <= 0f) {
            animator.SetTrigger("Vulnerable");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        shoot.GetComponent<BossAlkieElectricCurtain>().enabled = false;
        animator.ResetTrigger("Vulnerable");
    }
}
