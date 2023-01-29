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
    private void Start()
    {
        saveState = FindObjectOfType<SaveState>();
        moveMouseDirectionFire = GetComponent<MoveMouseDirectionFire>(); 
        FireXpBar = GameObject.Find("FireXpBar").GetComponent<Slider>();
        FireLevel = GameObject.Find("FireLevel").GetComponent<TextMeshProUGUI>();
        FireLevelUp = GameObject.Find("FireLevelUp").GetComponent<TextMeshProUGUI>();
        saveXp = FindObjectOfType<SaveXp>();
    }
    void Update()
    {
        if (level < 5f)
        {
            FireLevel.text = "Lvl. " + level;
            FireLevelUp.text = currentXp + "/" + levelUpXp;
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
            levelUpXp = 75;
        }
        if (level >= 2)
        {
            moveMouseDirectionFire.scale = new Vector3(0.3f, 0.3f, 0.3f);
            moveMouseDirectionFire.fireDamage = 25f;
            moveMouseDirectionFire.force = 2f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 1.5f;
            moveMouseDirectionFire.manaCost = 15f;
            saveState.burnprobability = 10f;
            saveState.burnduration = 4f;
            saveState.burndamageOverTime = 5f;
            saveState.burntimeBetweenDamage = 2f;
            levelUpXp = 500f;
        }
        if (level >= 3)
        {
            moveMouseDirectionFire.scale = new Vector3(0.4f, 0.4f, 0.4f);
            moveMouseDirectionFire.fireDamage = 50f;
            moveMouseDirectionFire.force = 3f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 1f;
            moveMouseDirectionFire.manaCost = 25f;
            moveMouseDirectionFire.piercing = true;
            saveState.burnprobability = 20;
            saveState.burnduration = 4f;
            saveState.burndamageOverTime = 10f;
            saveState.burntimeBetweenDamage = 2f;
            levelUpXp = 1250f;
        }
        if (level >= 4)
        {
            moveMouseDirectionFire.scale = new Vector3(0.7f, 0.7f, 0.7f);
            moveMouseDirectionFire.fireDamage = 100f;
            moveMouseDirectionFire.force = 4f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.5f;
            moveMouseDirectionFire.manaCost = 35f;
            moveMouseDirectionFire.piercing = true;
            saveState.burnprobability = 30;
            saveState.burnduration = 5f;
            saveState.burndamageOverTime = 10f;
            saveState.burntimeBetweenDamage = 1f;
            levelUpXp = 2500f;
        }
        if (level >= 5)
        {
            moveMouseDirectionFire.scale = new Vector3(1f, 1f, 1f);
            moveMouseDirectionFire.fireDamage = 200f;
            moveMouseDirectionFire.force = 5f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.25f;
            moveMouseDirectionFire.manaCost = 50f;
            moveMouseDirectionFire.piercing = true;
            saveState.burnprobability = 50;
            saveState.burnduration = 6f;
            saveState.burndamageOverTime = 20f;
            saveState.burntimeBetweenDamage = 1f;
            FireLevel.fontSize = 26f;
            FireLevel.text = "Max Lvl. " + level;
            FireLevelUp.text ="";
        }
    }

    void LevelUp()
    {
        level++;
        if (level >= 5)
        {
            FireXpBar.value = 100;
            level = 5;
        }
        else
        {
            currentXp -= levelUpXp;
            FireXpBar.value = 0;
        }

    }
}
