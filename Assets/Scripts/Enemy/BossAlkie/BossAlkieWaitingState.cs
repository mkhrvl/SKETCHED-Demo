using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlkieWaitingState : StateMachineBehaviour
{
    GameObject playerUI;
    GameObject bossUI;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerUI = GameObject.Find("PlayerCanvas");
        bossUI = GameObject.Find("BossCanvas");

        playerUI.SetActive(false);
        bossUI.SetActive(false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerUI.SetActive(true);
        bossUI.SetActive(true);
    }
}
