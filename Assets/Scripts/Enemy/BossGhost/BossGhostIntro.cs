using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossGhostIntro : StateMachineBehaviour
{
    CinemachineVirtualCamera vcam;
    GameObject boss;
    GameObject player;

    GameObject playerUI;
    GameObject bossUI;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player");
        vcam = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();

        playerUI = GameObject.Find("PlayerCanvas");
        bossUI = GameObject.Find("BossCanvas");

        playerUI.SetActive(false);
        bossUI.SetActive(false);

        boss = GameObject.FindGameObjectWithTag("Boss");
        vcam.Follow = boss.transform;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        vcam.Follow = player.transform;
        
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;

        playerUI.SetActive(true);
        bossUI.SetActive(true);
    }
}
