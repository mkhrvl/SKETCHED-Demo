using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum State {
        Normal,
        Rolling,
    }

    private State state;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 moveDirection;
    private Vector3 rollDirection;
    private Vector3 lastMoveDirection;

    private float rollSpeed;

    public bool isRolling;
 
    private void Awake() {
        state = State.Normal;
        isRolling = false;
    }

    void Update() {
        switch(state) {
            case State.Normal:
                ProcessInputs();
                AnimatePlayer();

                if(Input.GetKeyDown(KeyCode.Space)) {
                    rollDirection = lastMoveDirection;
                    rollSpeed = 15f;
                    state = State.Rolling;
                }
                break;

            case State.Rolling: // ignores normal input when rolling
                isRolling = true;
                float rollSpeedDropMultiplier = 6f;
                rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                float rollSpeedMinimum = 4f;
                if (rollSpeed < rollSpeedMinimum) {
                    isRolling = false;
                    state = State.Normal;
                }    
                break;
        }
        /*
        else
        {   
            // resets player velocity when shooting
            rb.velocity = rb.velocity * 0f;
            // prevents walking animation when shooting / holding left mouse button
            animator.SetFloat("Speed", 0f);
        }
        */
    }

    // use FixedUpdate for physics related things 
    // based on a fixed timer unlike Update which is based on framerate
    void FixedUpdate() {
        switch(state) {
            case State.Normal:
                Move();  
            break;  
            case State.Rolling:
                rb.velocity = rollDirection * rollSpeed; // roll
            break;      
        }
    }

    // Player Input
    void ProcessInputs() {
        moveDirection.x = Input.GetAxisRaw("Horizontal");    // left and right
        moveDirection.y = Input.GetAxisRaw("Vertical");      // up and down

        moveDirection = new Vector2(moveDirection.x, moveDirection.y).normalized;   // set diagonal magnitude to 1 to avoid speeding up

        if (moveDirection.x != 0 || moveDirection.y != 0) {
            lastMoveDirection = moveDirection;
        }
    }

    // Movement Calculation
    void Move() {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void AnimatePlayer() {
        // walking animation
        animator.SetFloat("Horizontal", moveDirection.x);       
        animator.SetFloat("Vertical",moveDirection.y);          
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        //idle animation
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {
            animator.SetFloat("LastHorizontal", moveDirection.x);
            animator.SetFloat("LastVertical", moveDirection.y);
        }
    }
}
