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
    public float rotationSpeed = 50f;
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
            levelUpXp = 100;
            instantiateOnClickVoid.scale = new Vector3(0.15f, 0.15f, 0.15f);
            instantiateOnClickVoid.range = 0.7f;
            rotationSpeed = 50f;
        }
        if (level >= 2)
        {
            instantiateOnClickVoid.scale = new Vector3(0.2f, 0.2f, 0.2f);
            
            //instantiateOnClickVoid.fireDamage = 25f;
            //instantiateOnClickVoid.force = 2f;
            instantiateOnClickVoid.destroyDelay = 8f;
            instantiateOnClickVoid.cooldown = 14f;
            instantiateOnClickVoid.manaCost = 15f;
            instantiateOnClickVoid.range = 0.9f;
            levelUpXp = 300f;

            rotationSpeed = 60f;
        }
        if (level >= 3)
        {
            instantiateOnClickVoid.scale = new Vector3(0.25f, 0.25f, 0.25f);
            //instantiateOnClickVoid.fireDamage = 50f;

            rotationSpeed = 70f;
            instantiateOnClickVoid.destroyDelay = 8f;
            instantiateOnClickVoid.cooldown = 12f;
            instantiateOnClickVoid.manaCost = 25f;
            instantiateOnClickVoid.range = 1.1f;
            levelUpXp = 600f;
        }
        if (level >= 4)
        {
            instantiateOnClickVoid.scale = new Vector3(0.3f, 0.3f, 0.3f);
            //instantiateOnClickVoid.fireDamage = 100f;
            //instantiateOnClickVoid.force = 4f;
            rotationSpeed = 80f;
            instantiateOnClickVoid.destroyDelay = 8f;
            instantiateOnClickVoid.cooldown = 10f;
            instantiateOnClickVoid.manaCost = 35f;
            instantiateOnClickVoid.range = 1.4f;
            //instantiateOnClickVoid.piercing = true;
            levelUpXp = 1000f;
        }
        if (level >= 5)
        {
            instantiateOnClickVoid.scale = new Vector3(0.5f, 0.5f, 0.5f);
            //instantiateOnClickVoid.fireDamage = 200f;
            //instantiateOnClickVoid.force = 5f;
            rotationSpeed = 100f;
            instantiateOnClickVoid.destroyDelay = 8f;
            instantiateOnClickVoid.cooldown = 8f;
            instantiateOnClickVoid.manaCost = 50f;
            instantiateOnClickVoid.range = 1.8f;
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
