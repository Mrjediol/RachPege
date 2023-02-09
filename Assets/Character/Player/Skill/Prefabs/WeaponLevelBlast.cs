using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponLevelBlast : MonoBehaviour
{
    public float currentXp;
    public int level;
    public float levelUpXp = 10000;
    InstantiateOnClickFire InstantiateOnClickFire;
    private Slider blastXpBar;
    private TextMeshProUGUI BlastLevel;
    private TextMeshProUGUI BlastLevelUp;
    SaveXp saveXp;
    public float rotationSpeed = 50f;
    private void Start()
    {
        InstantiateOnClickFire = GetComponent<InstantiateOnClickFire>();
        blastXpBar = GameObject.Find("BlastXpBar").GetComponent<Slider>();
        BlastLevel = GameObject.Find("BlastLevel").GetComponent<TextMeshProUGUI>();
        BlastLevelUp = GameObject.Find("BlastLevelUp").GetComponent<TextMeshProUGUI>();
        saveXp = FindObjectOfType<SaveXp>();

    }
    void Update()
    {
        if (level < 5f)
        {
            BlastLevel.text = "Lvl. " + level;
            BlastLevelUp.text = currentXp + "/" + levelUpXp;
        }

        if (currentXp >= levelUpXp)
        {
            LevelUp();
        }
        blastXpBar.value = currentXp / levelUpXp;
        saveXp.Blastlevel = level;
        saveXp.Blastcurrentxp = currentXp;
        if (level >= 1)
        {
            levelUpXp = 100;
            InstantiateOnClickFire.scale = new Vector3(0.15f, 0.15f, 0.15f);
            InstantiateOnClickFire.cooldown = 3f;
            InstantiateOnClickFire.manaCost = 15f;
        }
        if (level >= 2)
        {
            InstantiateOnClickFire.scale = new Vector3(0.2f, 0.2f, 0.2f); 
            //instantiateOnClickVoid.fireDamage = 25f;
            //instantiateOnClickVoid.force = 2f;
            InstantiateOnClickFire.cooldown = 2f;
            InstantiateOnClickFire.manaCost = 20f;
            levelUpXp = 300f;
        }
        if (level >= 3)
        {
            InstantiateOnClickFire.scale = new Vector3(0.25f, 0.25f, 0.25f);
            //instantiateOnClickVoid.fireDamage = 50f;

            InstantiateOnClickFire.cooldown = 1.5f;
            InstantiateOnClickFire.manaCost = 25f;
            levelUpXp = 600f;
        }
        if (level >= 4)
        {
            InstantiateOnClickFire.scale = new Vector3(0.3f, 0.3f, 0.3f);
            //instantiateOnClickVoid.fireDamage = 100f;
            //instantiateOnClickVoid.force = 4f;
            rotationSpeed = 80f;
            InstantiateOnClickFire.cooldown = 1f;
            InstantiateOnClickFire.manaCost = 35f;
            //instantiateOnClickVoid.piercing = true;
            levelUpXp = 1000f;
        }
        if (level >= 5)
        {
            InstantiateOnClickFire.scale = new Vector3(0.5f, 0.5f, 0.5f);
            //instantiateOnClickVoid.fireDamage = 200f;
            //instantiateOnClickVoid.force = 5f;
            InstantiateOnClickFire.cooldown =  0.5f;
            InstantiateOnClickFire.manaCost = 50f;
            BlastLevel.fontSize = 26f;
            BlastLevel.text = "Max Lvl. " + level;
            BlastLevelUp.text ="";
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
        saveXp.SaveBlastXp();
    }
    private IEnumerator WaitAndSaveLvl()
    {
        yield return new WaitForEndOfFrame();
        saveXp.SaveBlastLevel();
    }
    void LevelUp()
    {
        level++;
        StartCoroutine(WaitAndSaveLvl());
        if (level >= 5)
        {
            blastXpBar.value = 100;
            level = 5;
        }
        else
        {
            currentXp -= levelUpXp;
            blastXpBar.value = 0;
        }

    }
}
