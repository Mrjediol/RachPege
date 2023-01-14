using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float enemyDamage = 3;

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

    private void Start() {
        animator = GetComponent<Animator>();
    }

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
