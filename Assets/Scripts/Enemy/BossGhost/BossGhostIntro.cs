using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossGhostIntro : StateMachineBehaviour
{
    CinemachineVirtualCamera vcam;
    GameObject boss;
    GameObject player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player");
        vcam = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();

        boss = GameObject.FindGameObjectWithTag("Boss");
        vcam.Follow = boss.transform;

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerShoot>().enabled = false;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       vcam.Follow = player.transform;

       player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
    }
}
