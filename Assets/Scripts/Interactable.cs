using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    void Update() {
        if(isInRange) {     // checks if player is in range
            if(Input.GetKeyDown(interactKey)) {     // checks if key is pressed
                interactAction.Invoke();    // fires event
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) { // checks if player is in range
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) { // checks if player is out of range
            isInRange = false;
        }
    } 
}
