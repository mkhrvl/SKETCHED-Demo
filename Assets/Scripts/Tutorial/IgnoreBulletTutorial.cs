using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreBulletTutorial : MonoBehaviour
{
    void Start() {
        Physics2D.IgnoreLayerCollision(9, 10, true);
    }
}
