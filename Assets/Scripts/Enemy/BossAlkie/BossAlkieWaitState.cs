using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlkieWaitState : StateMachineBehaviour
{
    GameObject playerUI;
    GameObject bossUI;
    GameObject bossName;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerUI = GameObject.Find("PlayerCanvas");
        bossUI = GameObject.Find("BossCanvas");
        bossName = GameObject.Find("BossName");

        playerUI.SetActive(false);
        bossUI.SetActive(false);
        bossName.SetActive(false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerUI.SetActive(true);
        bossUI.SetActive(true);
        bossName.SetActive(true);
    }
}
