using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiderBookVulnerable : StateMachineBehaviour
{

    GameObject heart;

    Collider2D invulnerableCollider;
    Collider2D vulnerableCollider;

    GameObject health;
    Hurtbox hurtbox;

    Rigidbody2D rb;
    Transform player;
    GameObject shoot;
    
    private Vector2 newPos;
    private Vector2 leftDistance;
    private Vector2 rightDistance;
    private Vector2 resetPosition;
    
    private bool reachedLeft;

    private int attackSet;

    public float bossSpeed = 5f;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = GameObject.Find("BossSpiderBook").GetComponent<Rigidbody2D>();     // gets rigidbody2d of BossSpiderBook since code is in BossGraphics

        shoot = GameObject.Find("BossSpiderBook");

        heart = GameObject.Find("Heart");
        heart.GetComponent<CircleCollider2D>().enabled = true;       // enable heart collider for vulnerable state

        vulnerableCollider = GameObject.Find("VulnerableCollider").GetComponent<PolygonCollider2D>();
        vulnerableCollider.enabled = true;       // enable body collider for vulnerable state
        
        invulnerableCollider = GameObject.Find("InvulnerableCollider").GetComponent<PolygonCollider2D>();
        invulnerableCollider.enabled = false;        // disable colliders for invulnerable state

        hurtbox = (Hurtbox) heart.GetComponent(typeof(Hurtbox));
        hurtbox.isHurt = false;

        leftDistance = new Vector2(-5.85f, rb.position.y);      // max distance boss can move to the left
        rightDistance = new Vector2(5.85f, rb.position.y);      // max distance boss can move to the right
        resetPosition = new Vector2(rb.position.x, rb.position.y);

        reachedLeft = false;

        attackSet = 4;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(shoot.GetComponent<BossShoot>().enabled == false)
        {
            shoot.GetComponent<BossShoot>().enabled = true; 
        }

        if(attackSet > 0 && !hurtbox.isHurt)
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

        else if(attackSet == 0 && rb.position.x != resetPosition.x)
        {
            newPos = Vector2.MoveTowards(rb.position, resetPosition, bossSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

        else if (hurtbox.isHurt)
        {
            hurtbox.isHurt = false;
            animator.SetTrigger("Invulnerable");
        }

        else
        {
            animator.SetTrigger("Invulnerable");      // transition to vulnerable state
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Invulnerable");

        heart.GetComponent<CircleCollider2D>().enabled = true;
        vulnerableCollider.enabled = false;
        invulnerableCollider.enabled = true;

        shoot.GetComponent<BossShoot>().enabled = false;
    }
}
