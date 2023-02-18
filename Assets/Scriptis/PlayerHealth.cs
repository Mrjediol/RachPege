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
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;
    public bool damagable = true;
    Animator animator;
    public int Scene;
    public GameObject damageText;
    private void Start()
    {
        animator = GetComponent<Animator>();
        LevelSystem player = GetComponent<LevelSystem>();
        maxhealth += player.level * 5f;
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

 
    
    //  public void Damagable()
    //{
    //    damagable = false;
    //}

           
    public void TakeDamage(float damage)
    {
        if (damagable == true)
        {
            health -= damage;
            animator.SetTrigger("Damaged");
            RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
            textTransform.GetComponent<TextMeshProUGUI>().text = "- " + damage.ToString();
            textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            textTransform.SetParent(canvas.transform);
            
            lerpTimer = 0f;
        }
        
    }

    public void RestoreHealth(float healAmout)
    {
        health += healAmout;
        RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();
        textTransform.GetComponent<TextMeshProUGUI>().text = "+ " + healAmout.ToString();
        textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        textTransform.SetParent(canvas.transform);
        lerpTimer = 0f;
    }
    public void IncreaseHealth(int level)
    {
        maxhealth += level * 5f;
        maxhealth = Mathf.Round(maxhealth);
        health += level * 5f;
        health = Mathf.Round(health);
    }

}
