using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Transform player;
    public float attackDistance = 0.5f;
    public float runDistance = 1f;
    public float speed = 0.3f;
    public float initialSpeed;
    public float bulletSpeed = 3f;
    private Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    public bool isHit;
// Start is called before the first frame update
void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
         if (distance < attackDistance)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
            Run();
        }
        else if (distance < runDistance)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
            Run();
        }
       
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }
    }


    private void Run()
    {
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        if (!isHit)
        {
            rb.MovePosition(newPos);
        }

    }
    public void ResetIsHit()
    {
       
    }
    public void SpeedReset()
    {
        speed = initialSpeed;
        isHit = false;
    }
}
