using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : StateMachineBehaviour
{

    public float speed;
    public float attackRange = 0.5f;

    public float cooldown = 3f;
    private float nextFireTime;
    Transform player;
    Rigidbody2D rb;
    Enemy enemy;
    
    public float dashRange = 0.5f;


    public float dashcooldown = 10f;
    private float dashnextFireTime;
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

        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 dirToPlayer = rb.position - target;
        Vector2 newPos = rb.position + dirToPlayer.normalized * 0.005f;
        if (Vector2.Distance(player.position, rb.position) <= 2f && enemy.rangeEnemy)
        {
            rb.MovePosition(newPos);
            Debug.Log("soy range voy a por ti");
        }
        else
        {
            if (enemy.rangeEnemy == false)
            {
                Vector2 newPos1 = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos1);
                Debug.Log("no soy range voy a por ti");
            }
        }
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (Time.time > nextFireTime && enemy.rangeEnemy)
            {
                animator.SetTrigger("Attack");
                nextFireTime = Time.time + cooldown;
                return;
            }
            else
            {
                if(enemy.rangeEnemy)
                animator.SetTrigger("Charge");
            }
            if(enemy.rangeEnemy == false)
            animator.SetTrigger("Attack");
        }

        if (Vector2.Distance(player.position, rb.position) <= dashRange && enemy.rangeEnemy)
        {
            Debug.Log("distancia menos a dashrange");
            if (Time.time > dashnextFireTime)
            {
                Debug.Log("deberia dashear");
                animator.SetTrigger("Dash");
                dashnextFireTime = Time.time + dashcooldown;
            }
 
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


}
