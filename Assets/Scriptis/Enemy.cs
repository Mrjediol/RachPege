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
    public float moveSpeed = 50f;
    public float slowedmoveSpeed = 10;
    public float dashSpeed = 5000f;
    public float SloweddashSpeed = 500f;
    Rigidbody2D rb;
    public float giveXP;
    public float enemyLvl;
    public float health;
    public float maxHealth = 5;
    public EnemyHealthBar healthBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI healthText;
    public float knowback = 1000f;
    public bool damagable = true;
    
    public Spawner spawner;
    public delegate void OnEnemyKilled();
    public FrozenEffect frozenEffect;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


        spawner.onEnemyKilled += RemoveEnemy;


        enemyDamage *= enemyLvl;
        giveXP *= enemyLvl;
        maxHealth *= enemyLvl;
        health = maxHealth;
        levelText.text = "Lvl." + enemyLvl;
        xpText.text = giveXP + " Xp";
        healthBar.SetHealth(health,maxHealth);
        healthText.text = Health + "/" + maxHealth;


    }
    void FixedUpdate()
    {   
        if (detectionZone.detectedObjs != null && detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;

            rb.AddForce(moveSpeed * Time.fixedDeltaTime * direction);
            
        }
        if (frozenEffect.isFrozen)
        {
            moveSpeed = slowedmoveSpeed;
            dashSpeed = SloweddashSpeed;
        }
        else
        {
            moveSpeed = 50f;
            dashSpeed = 5000f;
            
        }
    }

    public void Dash()
    {
        if (detectionZone.detectedObjs != null && detectionZone.detectedObjs.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            rb.AddForce(dashSpeed * Time.fixedDeltaTime * direction);
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

        //Debug.Log ("te imaginas que funciona");
        animator.SetTrigger("Damaged");
    }
    public void Takehit(float damageRevice)
    {
        if (damagable == true)
        {
            Health -= damageRevice;
            healthBar.SetHealth(health, maxHealth);
            healthText.text = Health + "/" + maxHealth;
            Debug.Log(gameObject.name);
            // Check if the list is not empty before trying to access an element
            SwordAttack swordAttack = FindObjectOfType<SwordAttack>();

            Vector2 direction = (transform.position - swordAttack.transform.position).normalized;

                rb.AddForce(knowback * Time.fixedDeltaTime * direction);

               
           
        }
    }

    public void Defeated(){

        

        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy()
    {
        LevelSystem XP = FindObjectOfType<LevelSystem>();
        XP.GainExperienceFlatRate(giveXP);
        spawner.DecreaseActiveEnemies();
        Destroy(gameObject);
    }





}
