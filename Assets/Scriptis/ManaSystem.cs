using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManaSystem : MonoBehaviour

{
   
    public Image manaBar;
    public TextMeshProUGUI manaText;
    public float maxMana;
    public float currentMana;
    public float manaregen = 1;

    void Awake()
    {
        LevelSystem levelsystem = GetComponent<LevelSystem>();
        currentMana = 100 + (levelsystem.level * 10f);
    }
    private void Update()
    {
        manaBar.fillAmount = Mathf.MoveTowards(currentMana / maxMana, 1f, Time.deltaTime * (0.01f * manaregen));
        currentMana = Mathf.MoveTowards(currentMana / maxMana, 1f, Time.deltaTime * (0.01f * manaregen)) * maxMana;

        if (currentMana < 0)
        {
            currentMana = 0;
        }
        manaText.text = "" + Mathf.FloorToInt(currentMana);
        LevelSystem levelsystem = GetComponent<LevelSystem>();
        maxMana = 100 + (levelsystem.level * 10f);
        manaregen = 1 + (levelsystem.level / 5);
    }


    public void ReduceMana(float mana)
    {
        if (mana<=currentMana)
        {
            currentMana -= mana;
            manaBar.fillAmount -= mana / maxMana;
        }
    }


















}
