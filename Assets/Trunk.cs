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
    public bool isHit;
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
            animator.SetBool("Attack", false);
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



    //private void Run()
    //{
    //    Vector3 direction = (transform.position - playerTransform.position).normalized;
    //    Vector2 movement = new Vector2(direction.x, direction.y);

    //    int layerMask = LayerMask.GetMask("Terrain", "fences");

    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.1f, layerMask);
    //    if (hit.collider != null)
    //    {
    //        // There's an obstacle in front of the enemy, so we need to adjust the movement direction
    //        Vector2 perpendicularDirection = new Vector2(-direction.y, direction.x);

    //        // Check if we can move to the left or right
    //        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, perpendicularDirection, 0.1f, layerMask);
    //        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, -perpendicularDirection, 0.1f, layerMask);


    //        if (leftHit.collider != null && rightHit.collider != null)
    //        {
    //            // We're stuck, so just stop moving
    //            GetComponent<Rigidbody2D>().velocity = movement * speed;
    //            Debug.Log("primero");
    //            return;
    //        }

    //        if (leftHit.collider == null)
    //        {
    //            // Move to the left
    //            movement = perpendicularDirection;
    //            Debug.Log("segundo");
    //        }
    //        else if (rightHit.collider == null)
    //        {
    //            // Move to the right
    //            movement = -perpendicularDirection;
    //            Debug.Log("tercero");
    //        }
    //    }

    //    GetComponent<Rigidbody2D>().velocity = movement * speed;
    //}
    private void Run()
    {
        Vector3 direction = (transform.position - playerTransform.position).normalized;
        Vector2 movement = new Vector2(direction.x, direction.y);

        int layerMask = LayerMask.GetMask("Terrain", "fences");

        // Check if we can move in the opposite direction to the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -direction, 0.1f, layerMask);
        if (hit.collider != null)
        {
            // There's an obstacle behind the enemy, so we need to adjust the movement direction
            Vector2 perpendicularDirection = new Vector2(-direction.y, direction.x);

            // Check if we can move to the left or right
            RaycastHit2D leftHit = Physics2D.Raycast(transform.position, perpendicularDirection, 0.1f, layerMask);
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position, -perpendicularDirection, 0.1f, layerMask);

            // Check if we can move up or down
            RaycastHit2D upHit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f, layerMask);
            RaycastHit2D downHit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, layerMask);

            // Determine the best direction to move based on the available paths
            if (leftHit.collider == null)
            {
                movement = perpendicularDirection;
            }
            else if (rightHit.collider == null)
            {
                movement = -perpendicularDirection;
            }
            else if (upHit.collider == null)
            {
                movement = -Vector2.up;
            }
            else if (downHit.collider == null)
            {
                movement = Vector2.up;
            }
        }
        if (!isHit)
            GetComponent<Rigidbody2D>().velocity = movement * speed;
    }


    public void ResetIsHit()
    {
        isHit = false;
    }
    public void Attack()
    {
        Vector3 direction = (playerTransform.position - nuzle.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, nuzle.position, Quaternion.identity);
        projectile.transform.parent = transform;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(projectile, 1f);
    }


}



//private void Run()
//{
//    Vector3 direction = (transform.position - playerTransform.position).normalized;
//    Vector2 movement = new Vector2(direction.x, direction.y);
//    GetComponent<Rigidbody2D>().velocity = movement * speed;
//}