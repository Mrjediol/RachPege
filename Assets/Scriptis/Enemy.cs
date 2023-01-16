using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    Animator animator;
    public float enemyDamage = 3;
    public DetectionZone detectionZone;
    public float moveSpeed = 10f;
    Rigidbody2D rb;
    public float giveXP;
    public float enemyLvl;
    public float health;
    public float maxHealth = 5;
    public EnemyHealthBar healthBar;
    public TextMeshProUGUI levelText;
    public float knowback = 1000f;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
      
        enemyDamage *= enemyLvl;
        giveXP *= enemyLvl;
        maxHealth *= enemyLvl;

        health = maxHealth;
        levelText.text = "Level " + enemyLvl;
        healthBar.SetHealth(health,maxHealth);


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

 

    public void Damaged()
    {

        Debug.Log ("te imaginas que funciona");
        animator.SetTrigger("Damaged");
    }
    public void Takehit(float damageRevice)
    {
       
        Debug.Log("tlol");

        Vector2 direction = (transform.position - detectionZone.detectedObjs[0].transform.position).normalized;

        rb.AddForce(knowback * Time.fixedDeltaTime * direction);

        Health -= damageRevice;
        healthBar.SetHealth(health, maxHealth);
    }
    public void Defeated(){

        

        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy() 
    {
        LevelSystem XP = FindObjectOfType<LevelSystem>();
        XP.GainExperienceFlatRate(giveXP);
        Destroy(gameObject);
    }
}
