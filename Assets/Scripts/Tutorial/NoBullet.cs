using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBullet : MonoBehaviour
{
    public PlayerShoot shoot;

    void Start() {
        shoot.ammoAmount = 0;
    }
}
