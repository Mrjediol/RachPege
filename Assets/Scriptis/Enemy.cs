using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
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
    public bool rangeEnemy;
    AudioManager audioManager;
    public bool whiledashin;
    public GameObject effectonme;
    public Vector3 scale = new(0.2f, 0.2f, 0.2f);
    LevelSystem levelSystem;
    public float manaValue = 0;
    public bool imTrunk;
    public bool imSlime;
    public bool imFur;
    public bool imNinja;
    public bool imInvencible;
    PlayerController playerController;
    public float desactivateDistance = 4f;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        levelSystem = FindObjectOfType<LevelSystem>();
        audioManager = FindObjectOfType<AudioManager>();
        endGame = FindObjectOfType<EndGame>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spawner.onEnemyKilled += RemoveEnemy;
        giveXP = 5 * (enemyLvl * enemyLvl) + 5 * enemyLvl;
        maxHealth += 3 * (enemyLvl * enemyLvl) + 4 * enemyLvl;
        enemyDamage += 4 * (enemyLvl * enemyLvl) + 4 * enemyLvl;
        health = maxHealth;
        levelText.text = "Lvl." + enemyLvl;
        xpText.text = giveXP.ToString("N0", new CultureInfo("es-ES")) + " Xp";
        healthBar.SetHealth(health,maxHealth);
        healthText.text = Health.ToString("N0", new CultureInfo("es-ES")) + "/" + maxHealth.ToString("N0", new CultureInfo("es-ES"));
        moveSpeed += enemyLvl / 200f;
        initialSpeed = moveSpeed;
        slowedmoveSpeed = moveSpeed / 4;
        SetEnemyScale(enemyLvl);
        home = transform.position;

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
    private void Update()
    {
       
        float levelDiference = enemyLvl - levelSystem.level;
        if(levelDiference <= -1)
        {
            return;
        }
        else if (levelDiference <= 1)
        {
            healthText.color = Color.green; // verde
            levelText.color = Color.green;
            xpText.color = Color.green;
        }
        else if (levelDiference <= 2)
        {
            healthText.color = Color.yellow; // 
            levelText.color = Color.yellow;
            xpText.color = Color.yellow;
        }
        else if (levelDiference >= 3)
        {
            healthText.color = Color.red; // rojo
            levelText.color = Color.red;
            xpText.color = Color.red;
        }
        
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
    public void DoEffectOnme()
    {
        GameObject effect = Instantiate(effectonme, transform.position, Quaternion.identity);
        effect.transform.localScale = scale;
        ParticleSystem ps = effect.GetComponent<ParticleSystem>();
        Renderer psRenderer = ps.GetComponent<Renderer>();
        psRenderer.sortingOrder = 11;
        psRenderer.sortingLayerName = "arboles";
        foreach (Transform child in ps.transform)
        {
            // Obtener el componente Renderer de cada hijo
            Renderer childRenderer = child.GetComponent<Renderer>();

            // Si el hijo tiene un componente Renderer, ajustar su sorting order
            if (childRenderer != null)
            {
                childRenderer.sortingOrder = 11;
                psRenderer.sortingLayerName = "arboles";
            }
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
        if (imFur)
            DamagedFur();
        if (imSlime)
            DamagedSlime();
        if (imTrunk)
            DamagedTrunk();
        if (imNinja)
            DamagedNinja();


        //damaged.Play();
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
    public void DamagedTrunk()
    {
        audioManager.Play("TrunkDamaged");
        audioManager.Stop("TrunkAttack");
    }
    public void AttackSoundTrunk()
    {
        audioManager.Play("TrunkAttack");
    }
    public void DamagedNinja()
    {
        audioManager.Play("NinjaDamaged");
        audioManager.Stop("NinjaAttack");
    }
    public void AttackSoundNinja()
    {
        audioManager.Play("NinjaAttack");
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
            if (imInvencible)
                return;
            Health -= damageRevice;
            healthBar.SetHealth(health, maxHealth);
            healthText.text = Health.ToString("N0", new CultureInfo("es-ES")) + "/" + maxHealth.ToString("N0", new CultureInfo("es-ES"));
            RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
            textTransform.GetComponent<TextMeshProUGUI>().text = string.Format(CultureInfo.GetCultureInfo("es-ES"), "{0:N0}", damageRevice);
            textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            textTransform.transform.SetParent(canvas.transform);

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
        healthText.text = Health.ToString("N0", new CultureInfo("es-ES")) + "/" + maxHealth.ToString("N0", new CultureInfo("es-ES"));

        damageRevice = damageRevice * 2f;
        VoidAttack voidAttack = FindObjectOfType<VoidAttack>();
        RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
        textTransform.GetComponent<TextMeshProUGUI>().text = "+ " + string.Format(CultureInfo.GetCultureInfo("es-ES"), "{0:N0}", damageRevice);
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
       
        manaStar.GetComponent<ManaValue>().manaValue = manaValue;
        Destroy(gameObject);
    }

    public void FurDeath()
    {
        audioManager.Play("FurDeath");
    }
    public void SlimeDeath()
    {
        audioManager.Play("SlimeDeath");
    }
    public void TrunkDeath()
    {
        audioManager.Play("TrunkDeath");
    }
    public void NinjaDeath()
    {
        audioManager.Play("NinjaDeath");
    }
    public void AddForce()
    {

        Vector2 direction = (playerController.transform.position - transform.position).normalized; // Calcula la dirección hacia el jugador
        rb.AddForce(direction * 10f, ForceMode2D.Impulse); // Aplica un impulso de fuerza en la dirección calculada
    }


}
