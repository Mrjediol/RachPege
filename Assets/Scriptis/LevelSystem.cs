using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class LevelSystem : MonoBehaviour
{

    public int level;
    public float currentXp;
    public float requiredXp;
    private float lerpTimer;
    private float delayTimer;
    public bool unlokingActive;
    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpText;
    public DashAbility dashAbility;
    [Header("Multipliers")]
    [Range(1f,300f)]
    public float addtionMultiplies = 300;
    [Range(2f,4f)]
    public float powerMultiplier = 2;
    [Range(7f,14f)]
    public float divisionMultiplier = 7;
    private bool death;
    public GameObject dashUnlockedTextPrefab;
    private GameObject dashUnlockedTextInstance;
    private bool dashUnlockedTextShowed = false;
    public GameObject dashUnlockedVideo;

    SwordAttack swordAttack;
    // Start is called before the first frame update
    void Start()
    {
        currentXp = PlayerPrefs.GetFloat("CurrentXp", 1);
        requiredXp = CalculateRequiredXp();
        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        
        levelText.text = "Level " + level;
        death = false;
        dashAbility.GetComponent<DashAbility>();
        swordAttack = GetComponentInChildren<SwordAttack>();

    }
    public void Awake()
    {
        level = PlayerPrefs.GetInt("CurrentLevel", 1);
        if (level >= dashAbility.levelRequirement)
        {
            dashUnlockedTextShowed = true;
        }
    }
    public void stopTimeOnLock()
    {
        Time.timeScale = 0;
    }
    public void ShowTutorial()
    {
        dashUnlockedVideo.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (level >= dashAbility.levelRequirement && !dashUnlockedTextShowed)
        {
            
            dashAbility.Unlock();
            dashUnlockedTextInstance = Instantiate(dashUnlockedTextPrefab, transform.position, Quaternion.identity);
            stopTimeOnLock();
            ShowTutorial();
            StartCoroutine(DestroyAfterSeconds(dashUnlockedTextInstance, 2.0f));
            dashUnlockedTextShowed = true;
            unlokingActive = true;
            
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame && unlokingActive == true)
        {
            Time.timeScale = 1;
            dashUnlockedVideo.SetActive(false);
        }
        if (level >= dashAbility.levelRequirement)
        {
            dashAbility.Unlock();
        }
        else if (level < dashAbility.levelRequirement)
        {
            dashAbility.Lock();
            dashUnlockedTextShowed = false;
        }

        

        IEnumerator DestroyAfterSeconds(GameObject text, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 1;
        dashUnlockedVideo.SetActive(false);
        Destroy(text);
        unlokingActive = false;
    }


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
        PlayerPrefs.SetFloat("CurrentXp", currentXp); // guardar el nivel actual
        PlayerPrefs.Save();
    }
    public void LevelUp()
    {
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        GetComponent<PlayerHealth>().IncreaseHealth(level);
        swordAttack.DamageValue();

        //for ()
       
        requiredXp = CalculateRequiredXp();
        levelText.text = "Level " + level;

        PlayerPrefs.SetInt("CurrentLevel", level); // guardar el nivel actual
        PlayerPrefs.Save();
        SwordAttack[] swordAttacks = FindObjectsOfType<SwordAttack>();
        for (int i = 0; i < swordAttacks.Length; i++)
        {
            swordAttacks[i].IncreaseDamage(level);
        }
       
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
