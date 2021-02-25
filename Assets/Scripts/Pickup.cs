using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public HeartHealthSystem heartHealthSystem;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && heartHealthSystem.GetComponent<HeartHealthSystem>().health < 2)
        {
            Destroy(gameObject);
        }
    }
}
