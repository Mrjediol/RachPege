using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    public float lerpTimer;
    public float maxhealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

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
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(Random.Range(5, 10));
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            RestoreHealth(Random.Range(5, 10));
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
    }

    void TakeDamage(float damage)
    {
        animator.SetTrigger("Damaged");
        health -= damage;
        lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmout)
    {
        health += healAmout;
        lerpTimer = 0f;
    }

}
