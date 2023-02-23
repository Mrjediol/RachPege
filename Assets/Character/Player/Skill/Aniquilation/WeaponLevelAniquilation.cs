using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponLevelAniquilation : MonoBehaviour
{
    public float currentXp;
    public int level;
    public float levelUpXp = 10000;
    InstantiateAniquilation instantiateAniquilation;
    private Slider AniquilationXpBar;
    private TextMeshProUGUI AniquilationLevel;
    private TextMeshProUGUI AniquilationLevelUp;
    SaveXp saveXp;
    SwordAttack swordAttack;
    private void Start()
    {
        swordAttack = FindObjectOfType<SwordAttack>();
        instantiateAniquilation = GetComponent<InstantiateAniquilation>();
        AniquilationXpBar = GameObject.Find("AniquilationXpBar").GetComponent<Slider>();
        AniquilationLevel = GameObject.Find("AniquilationLevel").GetComponent<TextMeshProUGUI>();
        AniquilationLevelUp = GameObject.Find("AniquilationLevelUp").GetComponent<TextMeshProUGUI>();
        saveXp = FindObjectOfType<SaveXp>();

    }
    void Update()
    {
        if (level < 5f)
        {
            AniquilationLevel.text = "Lvl. " + level;
            AniquilationLevelUp.text = currentXp + "/" + levelUpXp;
        }

        if (currentXp >= levelUpXp)
        {
            LevelUp();
        }
        AniquilationXpBar.value = currentXp / levelUpXp;
        saveXp.Aniquilationlevel = level;
        saveXp.Aniquilationcurrentxp = currentXp;
        if (level >= 1)
        {
            levelUpXp = 50000f;
            instantiateAniquilation.scale = new Vector3(0.3f, 0.3f, 0.3f);
            instantiateAniquilation.initialDamage = swordAttack.damage * 0.75f;
            instantiateAniquilation.manaCost = 100f;
        }
        if (level >= 2)
        {
            instantiateAniquilation.scale = new Vector3(0.35f, 0.35f, 0.35f);
            
            //instantiateOnClickVoid.fireDamage = 25f;
            //instantiateOnClickVoid.force = 2f;
            instantiateAniquilation.cooldown = 5f;
            instantiateAniquilation.manaCost = 125;
            instantiateAniquilation.initialDamage = swordAttack.damage;
            levelUpXp = 200000;

        }
        if (level >= 3)
        {
            instantiateAniquilation.scale = new Vector3(0.4f, 0.4f, 0.4f);
            //instantiateOnClickVoid.fireDamage = 50f;
            instantiateAniquilation.cooldown = 4f;
            instantiateAniquilation.manaCost = 150;
            instantiateAniquilation.initialDamage = swordAttack.damage * 1.25f;
            levelUpXp = 1000000f;
        }
        if (level >= 4)
        {
            instantiateAniquilation.scale = new Vector3(0.45f, 0.45f, 0.45f);
            //instantiateOnClickVoid.fireDamage = 100f;
            //instantiateOnClickVoid.force = 4f;
            instantiateAniquilation.cooldown = 3f;
            instantiateAniquilation.manaCost = 175;
            instantiateAniquilation.initialDamage = swordAttack.damage * 1.5f;
            //instantiateOnClickVoid.piercing = true;
            levelUpXp = 5000000;
        }
        if (level >= 5)
        {
            instantiateAniquilation.scale = new Vector3(0.5f, 0.5f, 0.5f);
            //instantiateOnClickVoid.fireDamage = 200f;
            //instantiateOnClickVoid.force = 5f;
            if (saveXp.postGame == true)
            {
                instantiateAniquilation.cooldown = 0.5f;
                instantiateAniquilation.manaCost = 100f;
            }
            else
            {
                instantiateAniquilation.cooldown = 0.5f;
                instantiateAniquilation.manaCost = 200f;
            }
            
            instantiateAniquilation.minTime = 0.5f;
            
            instantiateAniquilation.initialDamage = swordAttack.damage * 2;
            AniquilationLevel.fontSize = 26f;
            AniquilationLevel.text = "Max Lvl. " + level;
            AniquilationLevelUp.text ="";
        }
    }
    public void GetXp(float xp)
    {
        currentXp += xp;
        StartCoroutine(WaitAndSave());
    }

    private IEnumerator WaitAndSave()
    {
        yield return new WaitForEndOfFrame();
        saveXp.SaveAniquilationXp();
    }
    private IEnumerator WaitAndSaveLvl()
    {
        yield return new WaitForEndOfFrame();
        saveXp.SaveAniquilationLevel();
    }
    void LevelUp()
    {
        level++;
        StartCoroutine(WaitAndSaveLvl());
        if (level >= 5)
        {
            AniquilationXpBar.value = 100;
            level = 5;
        }
        else
        {
            currentXp -= levelUpXp;
            AniquilationXpBar.value = 0;
        }

    }
}
