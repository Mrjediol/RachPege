using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHealth : MonoBehaviour
{
    private float health;
    public float lerpTimer;
    public float maxhealth = 100;
    public float chipSpeed = 2f;
    public Image fronHealthBar;
    public Image backHealthBar;


    private void Start()
    {
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
    }

    void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = fronHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxhealth;
        if(fillB > hFraction)
        {
            fronHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }


}
