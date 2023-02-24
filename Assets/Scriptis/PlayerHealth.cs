using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float lerpTimer;
    public float maxhealth = 100;
    public float cooldownTime = 15f;
    private bool canHeal = true;

    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;
    public bool damagable = true;
    Animator animator;
    public int Scene;
    public GameObject damageText;
    private float cooldownTimer = 0f;
    public Slider cooldownSlider;
    public GameObject HealEffect;
    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
    LevelSystem levelSystem;
    Rigidbody2D rb;
    public GameObject bloodEffect;
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        animator = GetComponent<Animator>();
        levelSystem = GetComponent<LevelSystem>();
        int level = levelSystem.level;
        maxhealth += 5f * (level * level) + 5 * level;
        health = maxhealth;
        cooldownSlider.minValue = 0f;
        cooldownSlider.maxValue = cooldownTime;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxhealth);
        UpdateHealthUI();
        if (canHeal)
        {
            cooldownSlider.value = 0f;
        }
        else
        {
            cooldownTimer += Time.deltaTime;
            cooldownSlider.value = cooldownTime - cooldownTimer;
            if (cooldownTimer >= cooldownTime)
            {
                canHeal = true;
                cooldownTimer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.H) && canHeal && health < maxhealth)
        {
            RestoreHealth(maxhealth * 0.6f);
            audioManager.Play("PlayerHeal");
        }
        if (health <= 0)
        {
           
            animator.SetTrigger("Defeated");
        }

    }
   
    public void PlayerDeath()
    {
        audioManager.Play("PlayerDeath");
    }
    void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxhealth;
        if(fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF,backHealthBar.fillAmount, percentComplete);
           

        }
        healthText.text = Mathf.Round(health) + "/" + Mathf.Round(maxhealth) + " HP";
    }

 
    
    //  public void Damagable()
    //{
    //    damagable = false;
    //}

           
    public void TakeDamage(float damage, Vector2 knockBack)
    {
        if (damagable == true)
        {
            health -= damage;
            animator.SetTrigger("Damaged");
            RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
            textTransform.GetComponent<TextMeshProUGUI>().text = "- " + damage.ToString();
            textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            FindObjectOfType<AudioManager>().Play("PlayerDamaged");
            rb.AddForce(knockBack, ForceMode2D.Impulse);

            GameObject effect = Instantiate(bloodEffect, transform.position, Quaternion.identity);
            effect.transform.localScale = scale;
            effect.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            Renderer psRenderer = ps.GetComponent<Renderer>();
            psRenderer.sortingOrder = 11;
            psRenderer.sortingLayerName = "arboles";

            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            textTransform.SetParent(canvas.transform);
            levelSystem.WasHit();
            lerpTimer = 0f;
        }
        
    }

    public void RestoreHealth(float healAmout)
    {
        health += healAmout;
        health = Mathf.Min(health, maxhealth);
        RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
        textTransform.GetComponent<TextMeshProUGUI>().text = "+ " + healAmout.ToString();
        textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        GameObject effect = Instantiate(HealEffect, transform.position, Quaternion.identity);
        effect.transform.localScale = scale;
        effect.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        ParticleSystem ps = effect.GetComponent<ParticleSystem>();
        Renderer psRenderer = ps.GetComponent<Renderer>();
        psRenderer.sortingOrder = 11;
        psRenderer.sortingLayerName = "arboles";

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        textTransform.SetParent(canvas.transform);
        canHeal = false;
        lerpTimer = 0f;

    }
    public void IncreaseHealth(int level)
    {
        maxhealth += 5f * (level * level) + 5 * level;
        maxhealth = Mathf.Round(maxhealth);
        health += 5f * (level * level) + 5 * level;
        health = Mathf.Round(health);
    }

}
