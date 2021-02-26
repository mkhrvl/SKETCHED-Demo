using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossAlkieIntro : StateMachineBehaviour
{
    CinemachineVirtualCamera vcam;
    GameObject boss;
    GameObject player;

    GameObject playerUI;
    GameObject bossUI;

    GameObject bossName;

    private float delay = 0.8f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player");
        vcam = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();

        playerUI = GameObject.Find("PlayerCanvas");
        bossUI = GameObject.Find("BossCanvas");
        bossName = GameObject.Find("BossName");

        playerUI.SetActive(false);
        bossUI.SetActive(false);
        bossName.SetActive(false);

        boss = GameObject.FindGameObjectWithTag("Boss");
        vcam.Follow = boss.transform;

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerShoot>().enabled = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        delay -= Time.fixedDeltaTime;

        if(delay <= 0) {
            bossName.SetActive(true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        vcam.Follow = player.transform;
        
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;

        playerUI.SetActive(true);
        bossUI.SetActive(true);

        bossName.SetActive(false);
    }
}
