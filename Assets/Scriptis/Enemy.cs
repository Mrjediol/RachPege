using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float enemyDamage = 3;
    public DetectionZone detectionZone;
    public float moveSpeed = 10f;
    Rigidbody2D rb;




    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
   
        if (detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;

            rb.AddForce(moveSpeed * Time.fixedDeltaTime * direction);
        }
    }
    public float Health 
    {
        set 
        {
            health = value;

            if(health <= 0) 
            {
                Defeated();
            }
            else
            {
                Damaged();
            }
        }
        get 
        {
            return health;
        }
    }

    public float health = 1;

    public void Damaged()
    {

        Debug.Log ("te imaginas que funciona");
        animator.SetTrigger("Damaged");
    }
    public void Defeated(){
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
