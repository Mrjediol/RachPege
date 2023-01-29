using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponLevelIce : MonoBehaviour
{
    public float currentXp;
    public int level;
    public float levelUpXp = 10000f;
    MoveMouseDirectionIce moveMouseDirectionIce;
    private Slider IceXpBar;
    private TextMeshProUGUI IceLevel;
    private TextMeshProUGUI IceLevelUp;
    SaveState saveState;
    SaveXp saveXp;
    private void Start()
    {
        saveState = FindObjectOfType<SaveState>();
        moveMouseDirectionIce = GetComponent<MoveMouseDirectionIce>();
        IceXpBar = GameObject.Find("IceXpBar").GetComponent<Slider>();
        IceLevel = GameObject.Find("IceLevel").GetComponent<TextMeshProUGUI>();
        IceLevelUp = GameObject.Find("IceLevelUp").GetComponent<TextMeshProUGUI>();
        saveXp = FindObjectOfType<SaveXp>();
    }
    void Update()
    {
        if(level < 5f)
        {
            IceLevel.text = "Lvl. " + level;
            IceLevelUp.text = currentXp + "/" + levelUpXp;
        }
        
        if (currentXp >= levelUpXp)
        {
            LevelUp();
        }
        IceXpBar.value = currentXp / levelUpXp;
        //Guardo la Experiencia en saveXp, para recogerla cuando equipe arma o cambie.
        saveXp.Icecurrentxp = currentXp;
        saveXp.Icelevel = level;
        if (level >= 1)
        {
            levelUpXp = 100;
        }
        if (level >= 2)
        {
            moveMouseDirectionIce.scale = new Vector3(0.3f, 0.3f, 0.3f);
            moveMouseDirectionIce.IceDamage = 25f;
            moveMouseDirectionIce.force = 2f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 1.5f;
            moveMouseDirectionIce.manaCost = 15f;
            saveState.fronzedprobability = 10f;
            saveState.frozenduration = 4f;
            saveState.frozendamageOverTime = 5f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 350f;
        }
        if (level >= 3)
        {
            moveMouseDirectionIce.scale = new Vector3(0.4f, 0.4f, 0.4f);
            moveMouseDirectionIce.IceDamage = 50f;
            moveMouseDirectionIce.force = 3f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 1f;
            moveMouseDirectionIce.manaCost = 20f;
            moveMouseDirectionIce.piercing = true;
            saveState.fronzedprobability = 25f;
            saveState.frozenduration = 6f;
            saveState.frozendamageOverTime = 5f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 800f;
        }
        if (level >= 4)
        {
            moveMouseDirectionIce.scale = new Vector3(0.6f, 0.6f, 0.6f);
            moveMouseDirectionIce.IceDamage = 75f;
            moveMouseDirectionIce.force = 4f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.5f;
            moveMouseDirectionIce.manaCost = 25f;
            moveMouseDirectionIce.piercing = true;
            saveState.fronzedprobability = 50f;
            saveState.frozenduration = 8f;
            saveState.frozendamageOverTime = 10f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 1500f;
        }
        if (level >= 5)
        {
            moveMouseDirectionIce.scale = new Vector3(0.8f, 0.8f, 0.8f);
            moveMouseDirectionIce.IceDamage = 100f;
            moveMouseDirectionIce.force = 5f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.25f;
            moveMouseDirectionIce.manaCost = 30f;
            moveMouseDirectionIce.piercing = true;
            saveState.fronzedprobability = 75f;
            saveState.frozenduration = 10f;
            saveState.frozendamageOverTime = 5f;
            saveState.frozentimeBetweenDamage = 2f;
            IceLevel.fontSize = 26f;
            IceLevel.text = "Max Lvl. " + level;
            IceLevelUp.text = "";
        }
    }

    void LevelUp()
    {
        level++;      
        if (level >= 5)
        {
            IceXpBar.value = 100;
            level = 5;
        }
        else
        {
            currentXp -= levelUpXp;
            IceXpBar.value = 0;
        }

    }
}
/*levelUpXp = Mathf.RoundToInt(levelUpXp * 5f);*/ // aumenta la cantidad de XP necesaria para subir de nivel
