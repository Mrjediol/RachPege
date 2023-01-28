using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponLevelIce : MonoBehaviour
{
    public float currentXp;
    public int level;
    public float levelUpXp = 100;
    MoveMouseDirectionIce moveMouseDirectionIce;
    private Slider IceXpBar;
    private TextMeshProUGUI IceLevel;
    SaveState saveState;
    private void Start()
    {
        saveState = FindObjectOfType<SaveState>();
        moveMouseDirectionIce = GetComponent<MoveMouseDirectionIce>();
        IceXpBar = GameObject.Find("IceXpBar").GetComponent<Slider>();
        IceLevel = GameObject.Find("IceLevel").GetComponent<TextMeshProUGUI>();
        
    }
    void Update()
    {
        IceLevel.text = "Lvl. " + level;

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
            saveState.fronzedprobability = 10f;
            saveState.frozenduration = 4f;
            saveState.frozendamageOverTime = 5f;
            saveState.frozentimeBetweenDamage = 2f;
           
        }
        if (level >= 3)
        {
            moveMouseDirectionIce.scale = new Vector3(0.4f, 0.4f, 0.4f);
            moveMouseDirectionIce.IceDamage = 50f;
            moveMouseDirectionIce.force = 3f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 1f;
            moveMouseDirectionIce.piercing = true;
            saveState.fronzedprobability = 25f;
            saveState.frozenduration = 6f;
            saveState.frozendamageOverTime = 5f;
            saveState.frozentimeBetweenDamage = 2f;
        }
        if (level >= 4)
        {
            moveMouseDirectionIce.scale = new Vector3(0.6f, 0.6f, 0.6f);
            moveMouseDirectionIce.IceDamage = 75f;
            moveMouseDirectionIce.force = 4f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.5f;
            moveMouseDirectionIce.piercing = true;
            saveState.fronzedprobability = 50f;
            saveState.frozenduration = 8f;
            saveState.frozendamageOverTime = 10f;
            saveState.frozentimeBetweenDamage = 2f;
        }
        if (level >= 5)
        {
            moveMouseDirectionIce.scale = new Vector3(0.8f, 0.8f, 0.8f);
            moveMouseDirectionIce.IceDamage = 100f;
            moveMouseDirectionIce.force = 5f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.25f;
            moveMouseDirectionIce.piercing = true;
            saveState.fronzedprobability = 75f;
            saveState.frozenduration = 10f;
            saveState.frozendamageOverTime = 5f;
            saveState.frozentimeBetweenDamage = 2f;
        }
    }

    void LevelUp()
    {
        level++;
        currentXp -= levelUpXp;
        levelUpXp = Mathf.RoundToInt(levelUpXp * 5f); // aumenta la cantidad de XP necesaria para subir de nivel
        IceXpBar.value = 0;
        
    }
}
