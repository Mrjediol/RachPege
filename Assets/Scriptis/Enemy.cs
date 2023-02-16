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
    public GameObject manaStarPrefab;
    public GameObject damageText;
    public Spawner spawner;
    public delegate void OnEnemyKilled();
    public FrozenEffect frozenEffect;
    public bool isFrozen = false;
    private float freezeTimer;
    [SerializeField] private AudioSource damaged;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        frozenEffect = GetComponent<FrozenEffect>();

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
        
        isFrozen = frozenEffect.isFrozen;
        if (isFrozen)
        {
            freezeTimer -= Time.deltaTime;
            moveSpeed = slowedmoveSpeed;
            dashSpeed = SloweddashSpeed;
            if (freezeTimer <= 0f)

            {
                isFrozen = false;

            }
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
        damaged.Play();
    }
    public void Takehit(float damageRevice)
    {
        if (damagable == true)
        {
            Health -= damageRevice;
            healthBar.SetHealth(health, maxHealth);
            healthText.text = Health + "/" + maxHealth;
            RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
            textTransform.GetComponent<TextMeshProUGUI>().text = damageRevice.ToString();
            textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            textTransform.SetParent(canvas.transform);
            Debug.Log(gameObject.name);
            // Check if the list is not empty before trying to access an element
            SwordAttack swordAttack = FindObjectOfType<SwordAttack>();

            Vector2 direction = (transform.position - swordAttack.transform.position).normalized;

                rb.AddForce(knowback * Time.fixedDeltaTime * direction);

               
           
        }
    }
    public float forceMagnitude = 50f;
    //bool attackActive = true;
    
    public IEnumerator VoidAttack(float damageRevice)
    {
        Debug.Log("llego al void");
        Health -= damageRevice;
        healthBar.SetHealth(health, maxHealth);
        healthText.text = Health + "/" + maxHealth;
        damageRevice = damageRevice * 2f;
        VoidAttack voidAttack = FindObjectOfType<VoidAttack>();
        RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
        textTransform.GetComponent<TextMeshProUGUI>().text = damageRevice.ToString();
        textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        textTransform.SetParent(canvas.transform);
        //Vector2 direction = (transform.position + voidAttack.transform.position).normalized;

        //rb.AddForce(knowback * Time.fixedDeltaTime * direction);
        //Vector2 direction = (voidAttack.transform.position - transform.position).normalized;

        while (/*attackActive && */(this != null))
        {
            if (gameObject == null) yield break;
            Vector2 direction1 = (voidAttack.transform.position - transform.position).normalized;
            rb.AddForce(forceMagnitude * Time.fixedDeltaTime * direction1);
            yield return null;
        }
        //yield return new WaitForEndOfFrame();
        //StopVoidAttack();


    }
    

 
    //public void StopVoidAttack()
    //{
    //    attackActive = false;
    //}
    public void Defeated(){

        

        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy()
    {
        LevelSystem XP = FindObjectOfType<LevelSystem>();
        XP.GainExperienceFlatRate(giveXP);
        spawner.DecreaseActiveEnemies();
        // Instanciar el prefab de la estrella de mana
        GameObject manaStar = Instantiate(manaStarPrefab, transform.position, Quaternion.identity);
        // Establecer el valor de manaValue en función del nivel del enemigo
        float manaValue = 0;
        if (enemyLvl == 1)
        {
            manaValue = 50;
        }
        else if (enemyLvl >= 100)
        {
            manaValue = 250;
        }
        else
        {
            manaValue = 50f + (enemyLvl - 1f) * 2f;
        }
        manaStar.GetComponent<ManaValue>().manaValue = manaValue;
        Destroy(gameObject);
    }

}
