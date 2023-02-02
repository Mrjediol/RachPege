using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponLevelVoid : MonoBehaviour
{
    public float currentXp;
    public int level;
    public float levelUpXp = 10000;
    InstantiateOnClickVoid instantiateOnClickVoid;
    private Slider VoidXpBar;
    private TextMeshProUGUI VoidLevel;
    private TextMeshProUGUI VoidLevelUp;
    SaveXp saveXp;
    private void Start()
    {
        instantiateOnClickVoid = GetComponent<InstantiateOnClickVoid>();
        VoidXpBar = GameObject.Find("VoidXpBar").GetComponent<Slider>();
        VoidLevel = GameObject.Find("VoidLevel").GetComponent<TextMeshProUGUI>();
        VoidLevelUp = GameObject.Find("VoidLevelUp").GetComponent<TextMeshProUGUI>();
        saveXp = FindObjectOfType<SaveXp>();
    }
    void Update()
    {
        if (level < 5f)
        {
            VoidLevel.text = "Lvl. " + level;
            VoidLevelUp.text = currentXp + "/" + levelUpXp;
        }

        if (currentXp >= levelUpXp)
        {
            LevelUp();
        }
        VoidXpBar.value = currentXp / levelUpXp;
        saveXp.Voidlevel = level;
        saveXp.Voidcurrentxp = currentXp;
        if (level >= 1)
        {
            levelUpXp = 75;
        }
        if (level >= 2)
        {
            instantiateOnClickVoid.scale = new Vector3(0.3f, 0.3f, 0.3f);
            //instantiateOnClickVoid.fireDamage = 25f;
            //instantiateOnClickVoid.force = 2f;
            instantiateOnClickVoid.destroyDelay = 1.5f;
            instantiateOnClickVoid.cooldown = 1.5f;
            instantiateOnClickVoid.manaCost = 15f;
            levelUpXp = 500f;
        }
        if (level >= 3)
        {
            instantiateOnClickVoid.scale = new Vector3(0.4f, 0.4f, 0.4f);
            //instantiateOnClickVoid.fireDamage = 50f;
            instantiateOnClickVoid.destroyDelay = 1.5f;
            instantiateOnClickVoid.cooldown = 1f;
            instantiateOnClickVoid.manaCost = 25f;
            levelUpXp = 1250f;
        }
        if (level >= 4)
        {
            instantiateOnClickVoid.scale = new Vector3(0.7f, 0.7f, 0.7f);
            //instantiateOnClickVoid.fireDamage = 100f;
            //instantiateOnClickVoid.force = 4f;
            instantiateOnClickVoid.destroyDelay = 1.5f;
            instantiateOnClickVoid.cooldown = 0.5f;
            instantiateOnClickVoid.manaCost = 35f;
            //instantiateOnClickVoid.piercing = true;
            levelUpXp = 2500f;
        }
        if (level >= 5)
        {
            instantiateOnClickVoid.scale = new Vector3(1f, 1f, 1f);
            //instantiateOnClickVoid.fireDamage = 200f;
            //instantiateOnClickVoid.force = 5f;
            instantiateOnClickVoid.destroyDelay = 1.5f;
            instantiateOnClickVoid.cooldown = 0.25f;
            instantiateOnClickVoid.manaCost = 50f;
            VoidLevel.fontSize = 26f;
            VoidLevel.text = "Max Lvl. " + level;
            VoidLevelUp.text ="";
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
        saveXp.SaveVoidXp();
    }
    private IEnumerator WaitAndSaveLvl()
    {
        yield return new WaitForEndOfFrame();
        saveXp.SaveVoidLevel();
    }
    void LevelUp()
    {
        level++;
        StartCoroutine(WaitAndSaveLvl());
        if (level >= 5)
        {
            VoidXpBar.value = 100;
            level = 5;
        }
        else
        {
            currentXp -= levelUpXp;
            VoidXpBar.value = 0;
        }

    }
}
