using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponLevelRay : MonoBehaviour
{
    public float currentXp;
    public int level;
    public float levelUpXp = 10000;
    MoveMouseDirectionRay moveMouseDirectionRay;
    private Slider RayXpBar;
    private TextMeshProUGUI RayLevel;
    private TextMeshProUGUI RayLevelUp;
    SaveXp saveXp;
    public float rotationSpeed = 50f;
    private void Start()
    {
        moveMouseDirectionRay = GetComponent<MoveMouseDirectionRay>();
        RayXpBar = GameObject.Find("RayXpBar").GetComponent<Slider>();
        RayLevel = GameObject.Find("RayLevel").GetComponent<TextMeshProUGUI>();
        RayLevelUp = GameObject.Find("RayLevelUp").GetComponent<TextMeshProUGUI>();
        saveXp = FindObjectOfType<SaveXp>();

    }
    void Update()
    {
        if (level < 5f)
        {
            RayLevel.text = "Lvl. " + level;
            RayLevelUp.text = currentXp + "/" + levelUpXp;
        }

        if (currentXp >= levelUpXp)
        {
            LevelUp();
        }
        RayXpBar.value = currentXp / levelUpXp;
        saveXp.Raylevel = level;
        saveXp.Raycurrentxp = currentXp;
        if (level >= 1)
        {
            levelUpXp = 100;
            moveMouseDirectionRay.scale = new Vector3(0.15f, 0.15f, 0.15f);
            moveMouseDirectionRay.cooldown = 3f;
            moveMouseDirectionRay.manaCost = 15f;
        }
        if (level >= 2)
        {
            moveMouseDirectionRay.scale = new Vector3(0.2f, 0.2f, 0.2f); 
            //instantiateOnClickVoid.fireDamage = 25f;
            //instantiateOnClickVoid.force = 2f;
            moveMouseDirectionRay.cooldown = 2f;
            moveMouseDirectionRay.manaCost = 20f;
            levelUpXp = 300f;
        }
        if (level >= 3)
        {
            moveMouseDirectionRay.scale = new Vector3(0.25f, 0.25f, 0.25f);
            //instantiateOnClickVoid.fireDamage = 50f;

            moveMouseDirectionRay.cooldown = 1.5f;
            moveMouseDirectionRay.manaCost = 25f;
            levelUpXp = 600f;
        }
        if (level >= 4)
        {
            moveMouseDirectionRay.scale = new Vector3(0.3f, 0.3f, 0.3f);
            //instantiateOnClickVoid.fireDamage = 100f;
            //instantiateOnClickVoid.force = 4f;
            rotationSpeed = 80f;
            moveMouseDirectionRay.cooldown = 1f;
            moveMouseDirectionRay.manaCost = 35f;
            //instantiateOnClickVoid.piercing = true;
            levelUpXp = 1000f;
        }
        if (level >= 5)
        {
            moveMouseDirectionRay.scale = new Vector3(0.5f, 0.5f, 0.5f);
            //instantiateOnClickVoid.fireDamage = 200f;
            //instantiateOnClickVoid.force = 5f;
            RayLevel.fontSize = 26f;
            RayLevel.text = "Max Lvl. " + level;
            RayLevelUp.text ="";
            if(saveXp.postGame == true)
            {
                moveMouseDirectionRay.cooldown = 0.25f;
                moveMouseDirectionRay.manaCost = 25f;
            }
            else
            {
            moveMouseDirectionRay.manaCost = 50f;
            moveMouseDirectionRay.cooldown = 0.5f;
            }
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
        saveXp.SaveRayXp();
    }
    private IEnumerator WaitAndSaveLvl()
    {
        yield return new WaitForEndOfFrame();
        saveXp.SaveRayLevel();
    }
    void LevelUp()
    {
        level++;
        StartCoroutine(WaitAndSaveLvl());
        if (level >= 5)
        {
            RayXpBar.value = 100;
            level = 5;
        }
        else
        {
            currentXp -= levelUpXp;
            RayXpBar.value = 0;
        }

    }
}
