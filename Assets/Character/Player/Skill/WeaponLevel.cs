using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponLevel : MonoBehaviour
{
    public float currentXp;
    public int level;
    public float levelUpXp = 100;
    MoveMouseDirectionIce moveMouseDirectionIce;
    private Slider IceXpBar;
    private void Start()
    {
         moveMouseDirectionIce = GetComponent<MoveMouseDirectionIce>();
           
        IceXpBar = GameObject.Find("IceXpBar").GetComponent<Slider>();
    }
    void Update()
    {
        if (currentXp >= levelUpXp)
        {
            LevelUp();
        }
        IceXpBar.value = currentXp / levelUpXp;
        if (level >= 2)
        {
            moveMouseDirectionIce.scale = new Vector3(0.3f, 0.3f, 0.3f);
            moveMouseDirectionIce.IceDamage = 25f;
            moveMouseDirectionIce.force = 2f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 1.5f;
        }
        if (level >= 3)
        {
            moveMouseDirectionIce.scale = new Vector3(0.4f, 0.4f, 0.4f);
            moveMouseDirectionIce.IceDamage = 50f;
            moveMouseDirectionIce.force = 3f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 1f;
            moveMouseDirectionIce.piercing = true;
        }
        if (level >= 4)
        {
            moveMouseDirectionIce.scale = new Vector3(0.7f, 0.7f, 0.7f);
            moveMouseDirectionIce.IceDamage = 100f;
            moveMouseDirectionIce.force = 4f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.5f;
            moveMouseDirectionIce.piercing = true;
        }
        if (level >= 5)
        {
            moveMouseDirectionIce.scale = new Vector3(1f, 1f, 1f);
            moveMouseDirectionIce.IceDamage = 200f;
            moveMouseDirectionIce.force = 5f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.25f;
            moveMouseDirectionIce.piercing = true;
        }
    }

    void LevelUp()
    {
        level++;
        currentXp -= levelUpXp;
        levelUpXp = Mathf.RoundToInt(levelUpXp * 1.5f); // aumenta la cantidad de XP necesaria para subir de nivel
        IceXpBar.value = 0;
    }
}
