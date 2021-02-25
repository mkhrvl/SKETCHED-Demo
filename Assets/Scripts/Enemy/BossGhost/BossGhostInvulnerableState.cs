using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGhostInvulnerableState : StateMachineBehaviour
{
    Rigidbody2D rb;
    GameObject shoot;
    
    public float bossSpeed = 5f;
    
    private Vector2 newPos;
    private Vector2 leftDistance;
    private Vector2 rightDistance;
    private Vector2 resetPosition;
    
    private bool reachedLeft;

    private int attackSet;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = GameObject.Find("Boss").GetComponent<Rigidbody2D>();     // gets rigidbody2d of Boss since code is in BossGraphics

        leftDistance = new Vector2(-5.85f, rb.position.y);      // max distance boss can move to the left
        rightDistance = new Vector2(5.85f, rb.position.y);      // max distance boss can move to the right
        resetPosition = new Vector2(rb.position.x, rb.position.y);

        reachedLeft = false;

        shoot = GameObject.Find("Boss");
        shoot.GetComponent<BossShoot>().enabled = true;     // enable shooting 

        attackSet = 4;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (shoot.GetComponent<BossShoot>().enabled == false)
        {
            shoot.GetComponent<BossShoot>().enabled = true;
        }

        if (attackSet > 0)
        {
            if(reachedLeft)
            {
                newPos = Vector2.MoveTowards(rb.position, rightDistance, bossSpeed * Time.fixedDeltaTime);   // moves towards right
            }
            else
            {
                newPos = Vector2.MoveTowards(rb.position, leftDistance, bossSpeed * Time.fixedDeltaTime);    // moves towards left
            }

            if(rb.position.x <= leftDistance.x)  // if boss has reached max distance to the left, move to the right 
            {
                reachedLeft = true;
            }
            else if(rb.position.x >= rightDistance.x)    // if boss has reached max distance to the right, move to the left 
            {
                reachedLeft = false;
                attackSet -= 1;     // apparently this is triggered twice, needs fixing later
            }

            rb.MovePosition(newPos);     // updates position of the boss
        }
        else if (attackSet == 0 && rb.position.x != resetPosition.x)    // boss moves to middle after 2 sets of attack
        {
            newPos = Vector2.MoveTowards(rb.position, resetPosition, bossSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else
        {
            animator.SetTrigger("ShowerAttack"); // transition to vulnerable state
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shoot.GetComponent<BossShoot>().enabled = false;
        animator.ResetTrigger("ShowerAttack");
    }
}
