using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject popUpUI;

    void Awake() {
        popUpUI.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            popUpUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            popUpUI.SetActive(false);
        }
    }
}
