using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Transform player;
    public float attackDistance = 0.5f;
    public float minDistance = 0.2f;
    public float runDistance = 1f;
    public float speed = 0.3f;
    public float initialSpeed;
    private Animator animator;
    Rigidbody2D rb;
    public bool isHit;
    public bool imNinja;
    public Transform attack;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        animator = GetComponent<Animator>();
        initialSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

         if (distance < minDistance && imNinja)
            {
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
            }

         else if (distance < attackDistance)
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
        if (!imNinja)
            return;
        if (player.transform.position.x > transform.position.x)
        {

            attack.position = transform.position + new Vector3(+0.10f, 0.063f, 0f);
        }
        else
        {
            attack.position = transform.position + new Vector3(-0.10f, 0.063f, 0f);
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

    public void SpeedReset()
    {
        speed = initialSpeed;
        isHit = false;
    }
}
