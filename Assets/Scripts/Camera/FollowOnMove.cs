using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowOnMove : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public CinemachineVirtualCamera vcam;

    private bool didMove;

    void Start() {
        didMove = false;
    }

    void Update() {
        if(animator.GetFloat("Speed") == 1 && didMove == false) {   // follow character only upon moving
            didMove = true;
            vcam.Follow = player.transform; // camera follows character
        }
    }
}
