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
    private void Start()
    {
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
            levelUpXp = 100;
            instantiateAniquilation.scale = new Vector3(0.3f, 0.3f, 0.3f);

        }
        if (level >= 2)
        {
            instantiateAniquilation.scale = new Vector3(0.35f, 0.35f, 0.35f);
            
            //instantiateOnClickVoid.fireDamage = 25f;
            //instantiateOnClickVoid.force = 2f;
            instantiateAniquilation.cooldown = 5f;
            instantiateAniquilation.manaCost = 15f;
            instantiateAniquilation.damage = 70f;
            levelUpXp = 300f;

        }
        if (level >= 3)
        {
            instantiateAniquilation.scale = new Vector3(0.4f, 0.4f, 0.4f);
            //instantiateOnClickVoid.fireDamage = 50f;
            instantiateAniquilation.cooldown = 4f;
            instantiateAniquilation.manaCost = 25f;
            instantiateAniquilation.damage = 90f;
            levelUpXp = 600f;
        }
        if (level >= 4)
        {
            instantiateAniquilation.scale = new Vector3(0.45f, 0.45f, 0.45f);
            //instantiateOnClickVoid.fireDamage = 100f;
            //instantiateOnClickVoid.force = 4f;
            instantiateAniquilation.cooldown = 3f;
            instantiateAniquilation.manaCost = 35f;
            instantiateAniquilation.damage = 110f;
            //instantiateOnClickVoid.piercing = true;
            levelUpXp = 1000f;
        }
        if (level >= 5)
        {
            instantiateAniquilation.scale = new Vector3(0.5f, 0.5f, 0.5f);
            //instantiateOnClickVoid.fireDamage = 200f;
            //instantiateOnClickVoid.force = 5f;
            instantiateAniquilation.cooldown = 2f;
            instantiateAniquilation.manaCost = 40f;
            instantiateAniquilation.damage = 150f;
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
