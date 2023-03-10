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
    CurrentChoise currentChoise;
    SwordAttack swordAttack;
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        swordAttack = FindObjectOfType<SwordAttack>();
        saveState = FindObjectOfType<SaveState>();
        moveMouseDirectionIce = GetComponent<MoveMouseDirectionIce>();
        IceXpBar = GameObject.Find("IceXpBar").GetComponent<Slider>();
        IceLevel = GameObject.Find("IceLevel").GetComponent<TextMeshProUGUI>();
        IceLevelUp = GameObject.Find("IceLevelUp").GetComponent<TextMeshProUGUI>();
        saveXp = FindObjectOfType<SaveXp>();
        currentChoise = FindObjectOfType<CurrentChoise>();
    }
    void Update()
    {
        if(level < 5f)
        {
            IceLevel.text = "Lvl. " + level;
            IceLevelUp.text = currentXp.ToString("F0") + "/" + levelUpXp;
        }

        if (currentXp >= levelUpXp)
        {
            LevelUp();
        }
        IceXpBar.value = currentXp / levelUpXp;
        //Guardo la Experiencia en saveXp, para recogerla cuando equipe arma o cambie.
        saveXp.Icecurrentxp = currentXp;
        saveXp.Icelevel = level;
        if (level >= 1 && currentChoise.currentmodeIceMedium == true)
        {
            moveMouseDirectionIce.IceDamage = swordAttack.damage/2;
            moveMouseDirectionIce.cooldown = 1.5f;
            moveMouseDirectionIce.manaCost = 25f;
            levelUpXp = 1500;
            moveMouseDirectionIce.scale = new Vector3(0.1f, 0.1f, 0.1f);
            moveMouseDirectionIce.force = 1f;
            saveState.iceDamage = swordAttack.damage  /2f;
            saveState.fronzedprobability = 20f;
            saveState.frozenduration = 6f;
            saveState.frozendamageOverTime = swordAttack.damage / 6f;
            saveState.frozentimeBetweenDamage = 2f;

        }
        if (level >= 1 && currentChoise.currentmodeIceSlow == true)
        {
            moveMouseDirectionIce.IceDamage = (swordAttack.damage / 2) * 2;
            moveMouseDirectionIce.cooldown = 3f;
            moveMouseDirectionIce.manaCost = 50f;
            levelUpXp = 1500;
            moveMouseDirectionIce.scale = new Vector3(0.15f, 0.15f, 0.15f);
            moveMouseDirectionIce.force = 1f;
            saveState.iceDamage = swordAttack.damage / 2f;
            saveState.fronzedprobability = 40f;
            saveState.frozenduration = 6f;
            saveState.frozendamageOverTime = swordAttack.damage / 6f;
            saveState.frozentimeBetweenDamage = 2f;

        }
        if (level >= 1 && currentChoise.currentmodeIceFast == true)
        {
            moveMouseDirectionIce.IceDamage = (swordAttack.damage / 2)/2;
            moveMouseDirectionIce.cooldown = 0.75f;
            moveMouseDirectionIce.manaCost = 13f;
            levelUpXp = 1500;
            moveMouseDirectionIce.scale = new Vector3(0.05f, 0.05f, 0.05f);
            moveMouseDirectionIce.force = 1f;
            saveState.iceDamage = swordAttack.damage / 2f;
            saveState.fronzedprobability = 10f;
            saveState.frozenduration = 6f;
            saveState.frozendamageOverTime = swordAttack.damage / 6f;
            saveState.frozentimeBetweenDamage = 2f;

        }
        if (level >= 2 && currentChoise.currentmodeIceMedium == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.15f, 0.15f, 0.15f);
            moveMouseDirectionIce.IceDamage = swordAttack.damage * 0.75f;
            moveMouseDirectionIce.force = 1.25f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 1.25f;
            moveMouseDirectionIce.manaCost = 35f;
            saveState.iceDamage = swordAttack.damage * 0.75f;
            saveState.fronzedprobability = 40f;
            saveState.frozenduration = 7f;
            saveState.frozendamageOverTime = swordAttack.damage / 6f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 5000;
        }
        if (level >= 2 && currentChoise.currentmodeIceSlow == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.2f, 0.2f, 0.2f);
            moveMouseDirectionIce.IceDamage = (swordAttack.damage * 0.75f)*2;
            moveMouseDirectionIce.force = 1.25f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 2.5f;
            moveMouseDirectionIce.manaCost = 70f;
            saveState.iceDamage = swordAttack.damage * 0.75f;
            saveState.fronzedprobability = 80f;
            saveState.frozenduration = 7f;
            saveState.frozendamageOverTime = swordAttack.damage / 6f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 5000;
        }
        if (level >= 2 && currentChoise.currentmodeIceFast == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.1f, 0.1f, 0.1f);
            moveMouseDirectionIce.IceDamage = (swordAttack.damage * 0.75f)/2;
            moveMouseDirectionIce.force = 1.25f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.63f;
            moveMouseDirectionIce.manaCost = 18f;
            saveState.iceDamage = swordAttack.damage * 0.75f;
            saveState.fronzedprobability = 20f;
            saveState.frozenduration = 7f;
            saveState.frozendamageOverTime = swordAttack.damage / 6f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 5000;
        }

        if (level >= 3 && currentChoise.currentmodeIceMedium == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.2f, 0.2f, 0.2f);
            moveMouseDirectionIce.IceDamage = swordAttack.damage;
            moveMouseDirectionIce.force = 1.5f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 1f;
            moveMouseDirectionIce.manaCost = 50f;
            moveMouseDirectionIce.piercing = true;
            saveState.iceDamage = swordAttack.damage;
            saveState.fronzedprobability = 60f;
            saveState.frozenduration = 8f;
            saveState.frozendamageOverTime = swordAttack.damage / 5f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 20000;
        }
        if (level >= 3 && currentChoise.currentmodeIceSlow == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.25f, 0.25f, 0.25f);
            moveMouseDirectionIce.IceDamage = swordAttack.damage * 2;
            moveMouseDirectionIce.force = 1.5f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 2f;
            moveMouseDirectionIce.manaCost = 100f;
            moveMouseDirectionIce.piercing = true;
            saveState.iceDamage = swordAttack.damage;
            saveState.fronzedprobability = 100f;
            saveState.frozenduration = 8f;
            saveState.frozendamageOverTime = swordAttack.damage / 4f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 20000;
        }
        if (level >= 3 && currentChoise.currentmodeIceFast == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.15f, 0.15f, 0.15f);
            moveMouseDirectionIce.IceDamage = swordAttack.damage /2;
            moveMouseDirectionIce.force = 1.5f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.5f;
            moveMouseDirectionIce.manaCost = 25f;
            moveMouseDirectionIce.piercing = true;
            saveState.iceDamage = swordAttack.damage;
            saveState.fronzedprobability = 30f;
            saveState.frozenduration = 8f;
            saveState.frozendamageOverTime = swordAttack.damage / 5f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 20000;
        }
        if (level >= 4 && currentChoise.currentmodeIceMedium == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.25f, 0.25f, 0.25f);
            moveMouseDirectionIce.IceDamage = swordAttack.damage * 1.25f;
            moveMouseDirectionIce.force = 1.75f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.75f;
            moveMouseDirectionIce.manaCost = 75f;
            moveMouseDirectionIce.piercing = true;
            saveState.iceDamage = swordAttack.damage * 1.25f;
            saveState.fronzedprobability = 80f;
            saveState.frozenduration = 9f;
            saveState.frozendamageOverTime = swordAttack.damage / 4f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 250000;
        }
        if (level >= 4 && currentChoise.currentmodeIceSlow == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.3f, 0.3f, 0.3f);
            moveMouseDirectionIce.IceDamage = (swordAttack.damage * 1.25f)*2;
            moveMouseDirectionIce.force = 1.75f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 1.5f;
            moveMouseDirectionIce.manaCost = 150f;
            moveMouseDirectionIce.piercing = true;
            saveState.iceDamage = swordAttack.damage * 1.25f;
            saveState.fronzedprobability = 100f;
            saveState.frozenduration = 9f;
            saveState.frozendamageOverTime = swordAttack.damage / 2f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 250000;
        }
        if (level >= 4 && currentChoise.currentmodeIceFast == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.2f, 0.2f, 0.2f);
            moveMouseDirectionIce.IceDamage = (swordAttack.damage * 1.25f)/2;
            moveMouseDirectionIce.force = 1.75f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.38f;
            moveMouseDirectionIce.manaCost = 38f;
            moveMouseDirectionIce.piercing = true;
            saveState.iceDamage = swordAttack.damage * 1.25f;
            saveState.fronzedprobability = 40f;
            saveState.frozenduration = 9f;
            saveState.frozendamageOverTime = swordAttack.damage / 4f;
            saveState.frozentimeBetweenDamage = 2f;
            levelUpXp = 250000;
        }

        if (level >= 5 && currentChoise.currentmodeIceMedium == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.3f, 0.3f, 0.3f);
            moveMouseDirectionIce.IceDamage = swordAttack.damage * 1.5f;
            moveMouseDirectionIce.force = 2f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.5f;
            moveMouseDirectionIce.manaCost = 100f;
            moveMouseDirectionIce.piercing = true;
            saveState.iceDamage = swordAttack.damage * 1.5f;
            saveState.fronzedprobability = 100f;
            saveState.frozenduration = 10f;
            saveState.frozendamageOverTime = swordAttack.damage /3f;
            saveState.frozentimeBetweenDamage = 2f;
            IceLevel.fontSize = 26f;
            IceLevel.text = "Max Lvl. " + level;
            IceLevelUp.text = "";
        }
        if (level >= 5 && currentChoise.currentmodeIceSlow == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.35f, 0.35f, 0.35f);
            moveMouseDirectionIce.IceDamage = (swordAttack.damage * 1.5f)*2;
            moveMouseDirectionIce.force = 2f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 1f;
            moveMouseDirectionIce.manaCost = 200f;
            moveMouseDirectionIce.piercing = true;
            saveState.iceDamage = swordAttack.damage * 1.5f;
            saveState.fronzedprobability = 100f;
            saveState.frozenduration = 10f;
            saveState.frozendamageOverTime = swordAttack.damage;
            saveState.frozentimeBetweenDamage = 2f;
            IceLevel.fontSize = 26f;
            IceLevel.text = "Max Lvl. " + level;
            IceLevelUp.text = "";
        }
        if (level >= 5 && currentChoise.currentmodeIceFast == true)
        {
            moveMouseDirectionIce.scale = new Vector3(0.25f, 0.25f, 0.25f);
            moveMouseDirectionIce.IceDamage = (swordAttack.damage * 1.5f)/2;
            moveMouseDirectionIce.force = 2f;
            moveMouseDirectionIce.destroyDelay = 1.5f;
            moveMouseDirectionIce.cooldown = 0.25f;
            moveMouseDirectionIce.manaCost = 50f;
            moveMouseDirectionIce.piercing = true;
            saveState.iceDamage = swordAttack.damage * 1.5f;
            saveState.fronzedprobability = 50f;
            saveState.frozenduration = 10f;
            saveState.frozendamageOverTime = swordAttack.damage / 3f;
            saveState.frozentimeBetweenDamage = 2f;
            IceLevel.fontSize = 26f;
            IceLevel.text = "Max Lvl. " + level;
            IceLevelUp.text = "";
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
        saveXp.SaveIceXp();
    }
    private IEnumerator WaitAndSaveLvl()
    {
        yield return new WaitForEndOfFrame();
        saveXp.SaveIceLevel();
    }
    void LevelUp()
    {
        level++;
        StartCoroutine(WaitAndSaveLvl());
        if (level >= 5)
        {
            IceXpBar.value = 100;
            level = 5;
        }
        else
        {
        audioManager.Play("IceLvlUp");
            currentXp -= levelUpXp;
            IceXpBar.value = 0;
        }

    }
}
/*levelUpXp = Mathf.RoundToInt(levelUpXp * 5f);*/ // aumenta la cantidad de XP necesaria para subir de nivel
