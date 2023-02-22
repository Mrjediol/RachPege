using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class LevelSystem : MonoBehaviour
{
    public GameObject Effect;
    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);

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
    public TextMeshProUGUI MultiplierText;
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
    public float xpMultiplier = 1f;
    SwordAttack[] swordAttacks;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
       
        currentXp = PlayerPrefs.GetFloat("CurrentXp", 1);
        requiredXp = PlayerPrefs.GetFloat("requiredXp", requiredXp);
        xpMultiplier = PlayerPrefs.GetFloat("xpMultiplier", xpMultiplier);
        audioManager = FindObjectOfType<AudioManager>();



        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        
        
        death = false;
        dashAbility.GetComponent<DashAbility>();
        swordAttacks = GetComponentsInChildren<SwordAttack>();
       
       
    }
    public void Awake()
    {
        level = PlayerPrefs.GetInt("CurrentLevel", 1);
        levelText.text = "Level " + level;

        if (level >= dashAbility.levelRequirement)
        {
            dashUnlockedTextShowed = true;
        }
        Debug.Log("Current Level: " + level);
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

    UpdateXpUI();

        if (death == true)
        {
            GainExperience(20);
           
        }
        if (currentXp >= requiredXp)
        {
            LevelUp();
        }
        death = false;
    }
    IEnumerator DestroyAfterSeconds(GameObject text, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 1;
        dashUnlockedVideo.SetActive(false);
        Destroy(text);
        unlokingActive = false;
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
        xpText.text = Mathf.RoundToInt(currentXp) + "/" + Mathf.RoundToInt(requiredXp);

        if (xpMultiplier < 3f)
            MultiplierText.text = "X " + xpMultiplier.ToString("F1");
        if (xpMultiplier >= 3f)
            MultiplierText.text = "X 3";
    }
    public void WasHit()
    {
        xpMultiplier = 1f;
        MultiplierText.text = "X " + xpMultiplier;
        PlayerPrefs.SetFloat("xpMultiplier", xpMultiplier);
        PlayerPrefs.Save();
    }
    public void GainExperience(float xpGained)
    {



        //Incrementar el multiplicador hasta un máximo de 3.
        if (xpMultiplier < 3f)
        {
            xpMultiplier += 0.1f;
        }

        // Ganar experiencia multiplicada por el multiplicador actual.
        float xpToGain = xpGained * xpMultiplier;
        currentXp += xpToGain;
        lerpTimer = 0f;
        PlayerPrefs.SetFloat("xpMultiplier", xpMultiplier);
        PlayerPrefs.Save();
        // Guardar el nivel actual en PlayerPrefs.
        PlayerPrefs.SetFloat("CurrentXp", currentXp);
        PlayerPrefs.Save();
    }
    public void LevelUp()
    {
        audioManager.Play("LvlUp");
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        GetComponent<PlayerHealth>().IncreaseHealth(level);
        foreach (SwordAttack swordAttack in swordAttacks)
        {
            swordAttack.DamageValue();
        }

        //for ()
        GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity);
        effect.transform.localScale = scale;
        ParticleSystem ps = effect.GetComponent<ParticleSystem>();
        Renderer psRenderer = ps.GetComponent<Renderer>();
        psRenderer.sortingOrder = 11;
        requiredXp += 100 * level;
        //requiredXp = CalculateRequiredXp();
        levelText.text = "Level " + level;

        SaveLevel();
        //for (int i = 0; i < swordAttacks.Length; i++)
        //{
        //    swordAttacks[i].IncreaseDamage(level);
        //}

    }
    public void SaveLevel() 
    {
        PlayerPrefs.SetInt("CurrentLevel", level); // guardar el nivel actual
        PlayerPrefs.SetFloat("requiredXp", requiredXp); // guardar el nivel actual
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("CurrentXp", currentXp);
        PlayerPrefs.Save();

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

        return 100 * (level - 1) + level - 1;

        //int solvedForRequieredXp = 0;
        //for(int levelCycle = 1; levelCycle <= level; levelCycle++)
        //{
        //    solvedForRequieredXp += (int)Mathf.Floor(levelCycle + addtionMultiplies * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        //}
        //return solvedForRequieredXp / 4;


    }
    public void Death()

    {
        Debug.Log("funciona");
        death = true;
    }
    
    
    
}
