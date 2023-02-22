using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public float SloweddashSpeed = 500f;
    public float slowedmoveSpeed = 10;
    public float moveSpeed = 0.1f;
    public float initialSpeed;
    public float knowback = 1000f;
    public float maxHealth = 5;
    public float enemyDamage = 5;
    public float health;
    public float enemyLvl;
    public float giveXP;
    public bool damagable = true;
    public bool isFrozen = false;
    public EnemyHealthBar healthBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI healthText;
    public GameObject manaStarPrefab;
    public GameObject damageText;
    public Spawner spawner;
    public FrozenEffect frozenEffect;
    private float freezeTimer;
    public delegate void OnEnemyKilled();
    [SerializeField] private AudioSource damaged;
    public Vector2 home;
    public int scoreValue = 1;
    public bool imtheBoss;
    // Variables públicas para configurar en el Inspector
    public float minScale = 0.5f;
    public float maxScale = 2.0f;
    EndGame endGame;
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        endGame = FindObjectOfType<EndGame>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        frozenEffect = GetComponent<FrozenEffect>();
        spawner.onEnemyKilled += RemoveEnemy;
        giveXP = 5 * (enemyLvl * enemyLvl) + 5 * enemyLvl;
        maxHealth += 3 * (enemyLvl * enemyLvl) + 3 * enemyLvl;
        enemyDamage += 4 * (enemyLvl * enemyLvl) + 4 * enemyLvl;
        health = maxHealth;
        levelText.text = "Lvl." + enemyLvl;
        xpText.text = giveXP + " Xp";
        healthBar.SetHealth(health,maxHealth);
        healthText.text = Health + "/" + maxHealth;
        moveSpeed += enemyLvl / 100f;

        SetEnemyScale(enemyLvl);
        home = transform.position;

    }
    private void Awake()
    {
        initialSpeed = moveSpeed;
    }
    public void SetSpeed() 
    {
        moveSpeed = initialSpeed;
    }
    void SetEnemyScale(float enemyLvl)
    {
        // Interpolar entre el valor mínimo y máximo basado en el nivel del enemigo
        float scale = Mathf.Lerp(minScale, maxScale, enemyLvl / 100);

        // Establecer la escala del enemigo
        transform.localScale = scale * Vector3.one;
    }
    //void FixedUpdate()
    //{   
    //    isFrozen = frozenEffect.isFrozen;
    //    if (isFrozen)
    //    {
    //        freezeTimer -= Time.deltaTime;
    //        moveSpeed = slowedmoveSpeed;
    //        dashSpeed = SloweddashSpeed;
    //        if (freezeTimer <= 0f)

    //        {
    //            isFrozen = false;

    //        }
    //    }
    //    else
    //    {
    //        moveSpeed = 50f;
    //        dashSpeed = 5000f;

    //    }

    //}
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
    public void AttackSoundFur()
    {
        audioManager.Play("FurAttack");
    }
    public void DamagedFur()
    {
        audioManager.Play("FurDamaged");
        audioManager.Stop("FurAttack");
    }
    public void AttackSoundSlime()
    {
        audioManager.Play("SlimeAttack");
    }
    public void DamagedSlime()
    {
        audioManager.Play("SlimeDamaged");
        audioManager.Stop("SlimeAttack");
    }
    public void Takehit(float damageRevice)
    {
        if (damagable == true)
        {
            Health -= damageRevice;
            healthBar.SetHealth(health, maxHealth);
            healthText.text = Health + "/" + maxHealth;
            RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
            textTransform.GetComponent<TextMeshProUGUI>().text = damageRevice.ToString("F0");
            textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            textTransform.SetParent(canvas.transform);
            Debug.Log(gameObject.name);
            // Check if the list is not empty before trying to access an element
            //SwordAttack swordAttack = FindObjectOfType<SwordAttack>();

            //Vector2 direction = (transform.position - swordAttack.transform.position).normalized;

            //rb.AddForce(knowback * Time.fixedDeltaTime * direction);               
        }
    }

    public float forceMagnitude = 50f;
    
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
    }
    public void Defeated()
    {
        animator.SetTrigger("Defeated");
        audioManager.Play("Death");

    }

    public void RemoveEnemy()
    {
        LevelSystem XP = FindObjectOfType<LevelSystem>();
        
        XP.GainExperience(giveXP);
        endGame.AddToScore(scoreValue);
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
