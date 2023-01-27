using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponLevelFire : MonoBehaviour
{
    public float currentXp;
    public int level;
    public float levelUpXp = 50;
    MoveMouseDirectionFire moveMouseDirectionFire;
    private Slider FireXpBar;
    private TextMeshProUGUI FireLevel;
    private void Start()
    {
        moveMouseDirectionFire = GetComponent<MoveMouseDirectionFire>(); 
        FireXpBar = GameObject.Find("FireXpBar").GetComponent<Slider>();
        FireLevel = GameObject.Find("FireLevel").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        FireLevel.text = "Lvl. " + level;
        if (currentXp >= levelUpXp)
        {
            LevelUp();
        }
        FireXpBar.value = currentXp / levelUpXp;
        if (level >= 2)
        {
            moveMouseDirectionFire.scale = new Vector3(0.3f, 0.3f, 0.3f);
            moveMouseDirectionFire.fireDamage = 25f;
            moveMouseDirectionFire.force = 2f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 1.5f;
            moveMouseDirectionFire.burnprobability = 10f;
            moveMouseDirectionFire.burnduration = 4f;
            moveMouseDirectionFire.burndamageOverTime = 5f;
            moveMouseDirectionFire.burntimeBetweenDamage = 2f;
        }
        if (level >= 3)
        {
            moveMouseDirectionFire.scale = new Vector3(0.4f, 0.4f, 0.4f);
            moveMouseDirectionFire.fireDamage = 50f;
            moveMouseDirectionFire.force = 3f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 1f;
            moveMouseDirectionFire.piercing = true;
            moveMouseDirectionFire.burnprobability = 20;
            moveMouseDirectionFire.burnduration = 4f;
            moveMouseDirectionFire.burndamageOverTime = 10f;
            moveMouseDirectionFire.burntimeBetweenDamage = 2f;
        }
        if (level >= 4)
        {
            moveMouseDirectionFire.scale = new Vector3(0.7f, 0.7f, 0.7f);
            moveMouseDirectionFire.fireDamage = 100f;
            moveMouseDirectionFire.force = 4f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.5f;
            moveMouseDirectionFire.piercing = true;
            moveMouseDirectionFire.burnprobability = 30;
            moveMouseDirectionFire.burnduration = 5f;
            moveMouseDirectionFire.burndamageOverTime = 10f;
            moveMouseDirectionFire.burntimeBetweenDamage = 1f;
        }
        if (level >= 5)
        {
            moveMouseDirectionFire.scale = new Vector3(1f, 1f, 1f);
            moveMouseDirectionFire.fireDamage = 200f;
            moveMouseDirectionFire.force = 5f;
            moveMouseDirectionFire.destroyDelay = 1.5f;
            moveMouseDirectionFire.cooldown = 0.25f;
            moveMouseDirectionFire.piercing = true;
            moveMouseDirectionFire.burnprobability = 50;
            moveMouseDirectionFire.burnduration = 6f;
            moveMouseDirectionFire.burndamageOverTime = 20f;
            moveMouseDirectionFire.burntimeBetweenDamage = 1f;
        }
    }

    void LevelUp()
    {
        level++;
        currentXp -= levelUpXp;
        levelUpXp = Mathf.RoundToInt(levelUpXp * 5f); // aumenta la cantidad de XP necesaria para subir de nivel
        FireXpBar.value = 0;
    }
}
