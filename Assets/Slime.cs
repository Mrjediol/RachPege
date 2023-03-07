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
    public bool frozen;
    Enemy enemy;
    AudioManager audioManager;
    private bool hasPlayedBossRageSound;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        animator = GetComponent<Animator>();
        initialSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        
        if (imNinja)
        {
            audioManager = FindObjectOfType<AudioManager>();
            audioManager.Play("BossSpawn");
            audioManager.Play("BossZone");
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(imNinja && enemy.health < (enemy.maxHealth/2f))
        {
            speed = 1f;
            animator.speed = 1.4f;
            if (!hasPlayedBossRageSound)
            {
                spriteRenderer.color = Color.red;
                audioManager.Play("BossRage");
                transform.localScale = new Vector3(1.65f, 1.65f, 1.65f);
                hasPlayedBossRageSound = true;
                audioManager.Stop("BossZone");
                audioManager.Play("SecondPhase");
            }

        }    
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
