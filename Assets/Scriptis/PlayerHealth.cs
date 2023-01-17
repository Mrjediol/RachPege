using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float lerpTimer;
    public float maxhealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        health = maxhealth;
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxhealth);
        UpdateHealthUI();
       
        if (Input.GetKeyDown(KeyCode.H))
        {
            RestoreHealth(Random.Range(5, 10));
        }
        if (health <= 0)
        {
            animator.SetTrigger("Defeated");
        }

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
        healthText.text = Mathf.Round(health) + "/" + Mathf.Round(maxhealth);
    }

 
    
      

           
    public void TakeDamage()
    {
        animator.SetTrigger("Damaged");
        lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmout)
    {
        health += healAmout;
        lerpTimer = 0f;
    }
    public void IncreaseHealth(int level)
    {
        maxhealth += (health * 0.01f) * ((100 - level) * 0.1f);
        maxhealth = Mathf.Round(maxhealth);
        health += (health * 0.01f) * ((100 - level) * 0.1f);
        health = Mathf.Round(health);
    }

}
