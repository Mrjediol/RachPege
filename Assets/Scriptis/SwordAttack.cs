using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 3;
    Vector2 rightAttackOffset;

    private void Start() {
       
        rightAttackOffset = transform.localPosition;
    }

    public void AttackRight() {

        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft() {

        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }


    /*private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy
            //Debug.Log("llego a 1");
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null) {
                Debug.Log("Hago Daño");

                enemy.Health -= damage;
            }
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Deal damage to the enemy
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                Debug.Log("Hago Daño");

                enemy.Health -= damage;
            }
        }
    }
    
}
