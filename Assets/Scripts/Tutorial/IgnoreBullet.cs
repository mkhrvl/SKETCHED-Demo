using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreBullet : MonoBehaviour
{
    void Start() {
        Physics2D.IgnoreLayerCollision(8, 9, true);
    }
}
