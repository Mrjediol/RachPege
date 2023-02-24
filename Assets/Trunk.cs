using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{

    public Transform playerTransform;
    public GameObject projectilePrefab;
    public float attackDistance = 2f;
    public float runDistance = 1f;
    public float speed = 0.3f;
    public float bulletSpeed = 3f;
    public Transform nuzle;
    private Animator animator;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
       
        if (distance < runDistance)
        {
            animator.SetBool("Run", true);
            Run(); 
        }
        else if (distance < attackDistance)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (playerTransform.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
            nuzle.position = transform.position + new Vector3(+0.10f, 0f, 0f);
        }
        else
        {
            spriteRenderer.flipX = false;
            nuzle.position = transform.position + new Vector3(-0.10f, 0f, 0f);
        }
    }

    private void Run()
    {
        Vector3 direction = (transform.position - playerTransform.position).normalized;
        Vector2 movement = new Vector2(direction.x, direction.y);
        GetComponent<Rigidbody2D>().velocity = movement * speed;
    }


    public void Attack()
    {
        Vector3 direction = (playerTransform.position - nuzle.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, nuzle.position, Quaternion.identity);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(projectile, 1f);
    }


}
