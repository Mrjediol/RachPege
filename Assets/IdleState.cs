using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{


    public float runRange = 5f;
    public float speed;
    public float homeRange = 0.6f;

    Transform player;
    Rigidbody2D rb;
    Enemy enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
        speed = enemy.moveSpeed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Vector2 target = new Vector2(enemy.home.position.x, enemy.home.position.y);
       
        if (Vector2.Distance(player.position, rb.position) <= runRange)
        {
            animator.SetTrigger("Run");
            return;
        }
        if (Vector2.Distance(enemy.home, rb.position) >= homeRange)
        {
            float distance = Vector2.Distance(enemy.home, rb.position);
            Debug.Log(distance);
            Vector2 newPos = Vector2.MoveTowards(rb.position, enemy.home, (speed/2) * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        {
            animator.ResetTrigger("Run");
            
        }
    }

}
