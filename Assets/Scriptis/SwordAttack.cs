using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 10;

    public float initialdamage = 10;
    Vector2 rightAttackOffset;
    public float knowbackForce = 1;
    LevelSystem levelSystem;
    public float mana;
    PlayerController playerController;
    private void Start() 
    {
        playerController = GetComponentInParent<PlayerController>();
        rightAttackOffset = transform.localPosition;
        levelSystem = GetComponentInParent<LevelSystem>();
        damage = PlayerPrefs.GetFloat("damage", damage);
    }
   public void DamageValue()
   {
        float level = levelSystem.level;
        damage = initialdamage;
        damage += 1f * ((level * level) + 1f * level) / 2;
        PlayerPrefs.SetFloat("damage", damage);
        PlayerPrefs.Save();
    }

    public void AttackRight() {
       
        transform.localPosition = rightAttackOffset;
    }
    public void GetMana()
    {

    }
    public void AttackLeft() {
      
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }



    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy
            //Debug.Log("llego a 1");
        Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null) {
                //Debug.Log("Hago Daño");
               
                
                    //enemy.Health -= damage;
            enemy.Takehit(damage);
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Vector2 direction = (rb.transform.position - transform.position).normalized;
            mana = enemy.manaValue;
            playerController.GetManaFromHit(mana/2, other);
            Vector2 knockBack = direction * knowbackForce;

            //rb.AddForce(knowback * Time.fixedDeltaTime * direction);

            rb.AddForce(knockBack, ForceMode2D.Impulse);

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
