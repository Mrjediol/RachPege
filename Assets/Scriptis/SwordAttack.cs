using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 10;
    public float initialdamage = 10;
    Vector2 rightAttackOffset;

    LevelSystem levelSystem;

    private void Start() 
    {
       
        rightAttackOffset = transform.localPosition;
        levelSystem = GetComponentInParent<LevelSystem>();
        damage = PlayerPrefs.GetFloat("damage", damage);
    }
   public void DamageValue()
   {
        float level = levelSystem.level;
        damage = 1f * ((level * level) + 1f * level) / 2;
        PlayerPrefs.SetFloat("damage", damage);
        PlayerPrefs.Save();
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


    Enemy enemy;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy
            //Debug.Log("llego a 1");
             enemy = other.GetComponent<Enemy>();

            if(enemy != null) {
                //Debug.Log("Hago Daño");
               
                
                    //enemy.Health -= damage;
                    enemy.Takehit(damage);
                
            }
        }
        DPS dps = other.GetComponent<DPS>();
        if (dps != null)
        {
            dps.TakeDamage(damage);
           
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.gameObject.tag == "Enemy")
    //    {
    //        // Deal damage to the enemy
    //        Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();

    //        if (enemy != null)
    //        {



    //            Debug.Log("Hago Daño");

    //            enemy.Takehit(damage);
    //        }
    //    }
    //}
   
}
