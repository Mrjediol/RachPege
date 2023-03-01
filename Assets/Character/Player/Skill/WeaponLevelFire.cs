using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponLevelFire : MonoBehaviour
{
    public float currentXp;
    public int level;
    public float levelUpXp = 10000;
    MoveMouseDirectionFire moveMouseDirectionFire;
    private Slider FireXpBar;
    private TextMeshProUGUI FireLevel;
    private TextMeshProUGUI FireLevelUp;
    SaveState saveState;
    SaveXp saveXp;
    CurrentChoise currentChoise;
    SwordAttack swordAttack;
    AudioManager audioManager;
    private void Start()
    {
        swordAttack = FindObjectOfType<SwordAttack>();
        saveState = FindObjectOfType<SaveState>();
        moveMouseDirectionFire = GetComponent<MoveMouseDirectionFire>(); 
        FireXpBar = GameObject.Find("FireXpBar").GetComponent<Slider>();
        FireLevel = GameObject.Find("FireLevel").GetComponent<TextMeshProUGUI>();
        FireLevelUp = GameObject.Find("FireLevelUp").GetComponent<TextMeshProUGUI>();
        saveXp = FindObjectOfType<SaveXp>();
        currentChoise = FindObjectOfType<CurrentChoise>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (level < 5f)
        {
            FireLevel.text = "Lvl. " + level;
            FireLevelUp.text = currentXp.ToString("F0") + "/" + levelUpXp;
        }

        if (currentXp >= levelUpXp)
        {
            LevelUp();
        }
        FireXpBar.value = currentXp / levelUpXp;
        saveXp.Firelevel = level;
        saveXp.Firecurrentxp = currentXp;
        if (level >= 1)
        {
            moveMouseDirectionFire.scale = new Vector3(0.1f, 0.1f, 0.1f);
            levelUpXp = 5000;
            moveMouseDirectionFire.fireDamage = swordAttack.damage;
            moveMouseDirectionFire.manaCost = 50f;
            moveMouseDirectionFire.cooldown = 1.5f;
            moveMouseDirectionFire.force = 1f;
            saveState.fireDamage = swordAttack.damage;
            saveState.burnprobability = 100f;
            saveState.burnduration = 4f;
            saveState.burndamageOverTime = swordAttack.damage / 4f;
            saveState.burntimeBetweenDamage = 1f;

        }
        if (level >= 2 && currentChoise.currentmodeMedium == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.15f, 0.152f, 0.15f);
            moveMouseDirectionFire.fireDamage = swordAttack.damage * 1.25f;
            moveMouseDirectionFire.force = 1.25f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 1.25f;
            moveMouseDirectionFire.manaCost = 75f;
            saveState.fireDamage = swordAttack.damage * 1.25f;
            saveState.burnprobability = 20f;
            saveState.burnduration = 6f;
            saveState.burndamageOverTime = swordAttack.damage / 4f; 
            saveState.burntimeBetweenDamage = 1f;
            levelUpXp = 10000f;
        }
        if (level >= 2 && currentChoise.currentmodeSlow == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.6f, 0.6f, 0.6f);
            moveMouseDirectionFire.fireDamage = swordAttack.damage * 2f;
            moveMouseDirectionFire.force = 1f;
            moveMouseDirectionFire.destroyDelay = 2f;
            moveMouseDirectionFire.cooldown = 3f;
            moveMouseDirectionFire.manaCost = 30f;
            saveState.burnprobability = 20f;
            saveState.burnduration = 4f;
            saveState.burndamageOverTime = 5f;
            saveState.burntimeBetweenDamage = 2f;
            levelUpXp = 500f;
        }
        if (level >= 2 && currentChoise.currentmodeFast == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.15f, 0.15f, 0.15f);
            moveMouseDirectionFire.fireDamage = swordAttack.damage * 1.5f;
            moveMouseDirectionFire.force = 3f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.75f;
            moveMouseDirectionFire.manaCost = 7.5f;
            saveState.burnprobability = 5f;
            saveState.burnduration = 4f;
            saveState.burndamageOverTime = 5f;
            saveState.burntimeBetweenDamage = 2f;
            levelUpXp = 500f;
        }

        if (level >= 3 && currentChoise.currentmodeMedium == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.2f, 0.2f, 0.2f);
            moveMouseDirectionFire.fireDamage = swordAttack.damage * 1.5f;
            moveMouseDirectionFire.force = 1.5f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 1f;
            moveMouseDirectionFire.manaCost = 100f;
            moveMouseDirectionFire.piercing = true;
            saveState.fireDamage = swordAttack.damage * 1.5f;
            saveState.burnprobability = 30;
            saveState.burnduration = 6f;
            saveState.burndamageOverTime = swordAttack.damage / 2f;
            saveState.burntimeBetweenDamage = 1f;
            levelUpXp = 100000;
        }
        if (level >= 3 && currentChoise.currentmodeFast == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.2f, 0.2f, 0.4f);
            moveMouseDirectionFire.fireDamage = 25f;
            moveMouseDirectionFire.force = 4f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.5f;
            moveMouseDirectionFire.manaCost = 12.5f;
            moveMouseDirectionFire.piercing = true;
            saveState.burnprobability = 10;
            saveState.burnduration = 4f;
            saveState.burndamageOverTime = 10f;
            saveState.burntimeBetweenDamage = 2f;
            levelUpXp = 1250f;
        }
        if (level >= 3 && currentChoise.currentmodeSlow == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.8f, 0.8f, 0.8f);
            moveMouseDirectionFire.fireDamage = 100f;
            moveMouseDirectionFire.force = 2f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 2f;
            moveMouseDirectionFire.manaCost = 50f;
            moveMouseDirectionFire.piercing = true;
            saveState.burnprobability = 40;
            saveState.burnduration = 4f;
            saveState.burndamageOverTime = 10f;
            saveState.burntimeBetweenDamage = 2f;
            levelUpXp = 1250f;
        }
        if (level >= 4 && currentChoise.currentmodeMedium == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.25f, 0.25f, 0.25f);
            moveMouseDirectionFire.fireDamage = swordAttack.damage * 2f;
            moveMouseDirectionFire.force = 1.75f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.75f;
            moveMouseDirectionFire.manaCost = 150f;
            moveMouseDirectionFire.piercing = true;
            saveState.fireDamage = swordAttack.damage * 2f;
            saveState.burnprobability = 40;
            saveState.burnduration = 8f;
            saveState.burndamageOverTime = swordAttack.damage / 2f;
            saveState.burntimeBetweenDamage = 1f;
            levelUpXp = 500000;
        }
        if (level >= 4 && currentChoise.currentmodeFast == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.25f, 0.25f, 0.25f);
            moveMouseDirectionFire.fireDamage = 50f;
            moveMouseDirectionFire.force = 5f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.25f;
            moveMouseDirectionFire.manaCost = 17.5f;
            moveMouseDirectionFire.piercing = true;
            saveState.burnprobability = 15;
            saveState.burnduration = 5f;
            saveState.burndamageOverTime = 10f;
            saveState.burntimeBetweenDamage = 1f;
            levelUpXp = 2500f;
        }
        if (level >= 4 && currentChoise.currentmodeSlow == true)
        {
            moveMouseDirectionFire.scale = new Vector3(1f, 1f, 1f);
            moveMouseDirectionFire.fireDamage = 200f;
            moveMouseDirectionFire.force = 3f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.5f;
            moveMouseDirectionFire.manaCost = 150f;
            moveMouseDirectionFire.piercing = true;
            saveState.burnprobability = 60;
            saveState.burnduration = 5f;
            saveState.burndamageOverTime = 10f;
            saveState.burntimeBetweenDamage = 1f;
            levelUpXp = 2500f;
        }
        if (level >= 5 && currentChoise.currentmodeMedium == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.3f, 0.3f, 0.3f);
            moveMouseDirectionFire.fireDamage = swordAttack.damage * 3f;
            moveMouseDirectionFire.force = 2f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.5f;
            moveMouseDirectionFire.manaCost = 200f;
            moveMouseDirectionFire.piercing = true;
            saveState.fireDamage = swordAttack.damage * 3f;
            saveState.burnprobability = 50;
            saveState.burnduration = 10f;
            saveState.burndamageOverTime = swordAttack.damage;
            saveState.burntimeBetweenDamage = 1f;
            FireLevel.fontSize = 26f;
            FireLevel.text = "Max Lvl. " + level;
            FireLevelUp.text ="";
        }
        if (level >= 5 && currentChoise.currentmodeFast == true)
        {
            moveMouseDirectionFire.scale = new Vector3(0.35f, 0.35f, 0.35f);
            moveMouseDirectionFire.fireDamage = 750f;
            moveMouseDirectionFire.force = 6f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.25f;
            moveMouseDirectionFire.manaCost = 125f;
            moveMouseDirectionFire.piercing = true;
            saveState.burnprobability = 25;
            saveState.burnduration = 6f;
            saveState.burndamageOverTime = 20f;
            saveState.burntimeBetweenDamage = 1f;
            FireLevel.fontSize = 26f;
            FireLevel.text = "Max Lvl. " + level;
            FireLevelUp.text = "";
        }
        if (level >= 5 && currentChoise.currentmodeSlow == true)
        {
            moveMouseDirectionFire.scale = new Vector3(1.4f, 1.4f, 1.4f);
            moveMouseDirectionFire.fireDamage = 3000f;
            moveMouseDirectionFire.force = 4f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.5f;
            moveMouseDirectionFire.manaCost = 5000f;
            moveMouseDirectionFire.piercing = true;
            saveState.burnprobability = 100;
            saveState.burnduration = 6f;
            saveState.burndamageOverTime = 20f;
            saveState.burntimeBetweenDamage = 1f;
            FireLevel.fontSize = 26f;
            FireLevel.text = "Max Lvl. " + level;
            FireLevelUp.text = "";
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
        saveXp.SaveFireXp();
    }
    private IEnumerator WaitAndSaveLvl()
    {
        yield return new WaitForEndOfFrame();
        saveXp.SaveFireLevel();
    }
    void LevelUp()
    {
        level++;
        StartCoroutine(WaitAndSaveLvl());
        if (level >= 5)
        {
            FireXpBar.value = 100;
            level = 5;
        }
        else
        {
        audioManager.Play("FireLvlUp");
            currentXp -= levelUpXp;
            FireXpBar.value = 0;
        }

    }
}
