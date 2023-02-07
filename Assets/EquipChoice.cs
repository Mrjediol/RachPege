using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipChoice : MonoBehaviour
{


    CurrentChoise currentChoise;
    public GameObject choiceMenu;
    private void Start()
    {
        currentChoise = FindObjectOfType<CurrentChoise>();

    }
        public void Fast()
    {
        currentChoise.currentmodeFast = true;
        currentChoise.currentmodeMedium = false;
        currentChoise.currentmodeSlow = false;
        Time.timeScale = 1;
        choiceMenu.SetActive(false);
    }

    public void Medium()
    {
        currentChoise.currentmodeFast = false;
        currentChoise.currentmodeMedium = true;
        currentChoise.currentmodeSlow = false;
        Time.timeScale = 1;
        choiceMenu.SetActive(false);
    }
    public void Slow()
    {
        currentChoise.currentmodeFast = false;
        currentChoise.currentmodeMedium = false;
        currentChoise.currentmodeSlow = true;
        Time.timeScale = 1;
        choiceMenu.SetActive(false);
    }
}
