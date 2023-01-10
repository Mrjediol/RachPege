using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    /*public enum AttackDirection
    {
        left, right
    }*/

    public float damage = 3;

    Vector2 rightattackOffset;
    
    Collider2D swordCollider;


    private void Start()
    {
        rightattackOffset = transform.position;
        swordCollider = GetComponent<Collider2D>();
    }

    /*public void Attack()
    {
        switch(attackDirection)
        {
            case AttackDirection.left:
                AttackLeft();
                break;
            case AttackDirection.right:
                AttackRight();
                break;
        }
    }*/
    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.position = rightattackOffset;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.position = new Vector3(rightattackOffset.x * -1, rightattackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Debug.Log("hitted");
            if(enemy != null)
            {
                enemy.Health -= damage;
            }
        } 
    }
}
