using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{

    public int level;
    public float currentXp;
    public float requiredXp;

    private float lerpTimer;
    private float delayTimer;
    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpText;

    [Header("Multipliers")]
    [Range(1f,300f)]
    public float addtionMultiplies = 300;
    [Range(2f,4f)]
    public float powerMultiplier = 2;
    [Range(7f,14f)]
    public float divisionMultiplier = 7;
    private bool death;

    // Start is called before the first frame update
    void Start()
    {
        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        requiredXp = CalculateRequiredXp();
        levelText.text = "Level " + level;
        death = false;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateXpUI();
        if (death == true)
        {
            GainExperienceFlatRate(20);
        }
        if (currentXp > requiredXp)
        {
            LevelUp();
        }
        death = false;
    }

    public void UpdateXpUI()
    {
        float xpFraction = currentXp / requiredXp;
        float FXP = frontXpBar.fillAmount;
        if(FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if(delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
            }
        }
        xpText.text = currentXp + "/" + requiredXp;
    }
    public void GainExperienceFlatRate(float xpGained)
    {
        currentXp += xpGained;
        lerpTimer = 0f;
    }
    public void LevelUp()
    {
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        GetComponent<PlayerHealth>().IncreaseHealth(level);
        requiredXp = CalculateRequiredXp();
        levelText.text = "Level" + level;
    }
    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if(passedLevel < level)
        {
            float multiplier = 1 + (level - passedLevel) * 0.1f;
            currentXp += xpGained * multiplier;
        }
        else
        {
            currentXp += xpGained;

        }
        lerpTimer = 0f;
        delayTimer = 0f;
    }

    private int CalculateRequiredXp()
    {
        int solvedForRequieredXp = 0;
        for(int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solvedForRequieredXp += (int)Mathf.Floor(levelCycle + addtionMultiplies * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solvedForRequieredXp / 4;
    }
    public void Death()

    {
        Debug.Log("funciona");
        death = true;
    }
    
    
    
}
