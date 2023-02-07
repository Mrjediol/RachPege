using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipChoice : MonoBehaviour
{


    CurrentChoise currentChoise;

    private void Start()
    {
        currentChoise = FindObjectOfType<CurrentChoise>();

    }
        public void Fast()
    {
        currentChoise.currentmodeFast = true;
        currentChoise.currentmodeMedium = false;
        currentChoise.currentmodeSlow = false;
    }

    public void Medium()
    {
        currentChoise.currentmodeFast = false;
        currentChoise.currentmodeMedium = true;
        currentChoise.currentmodeSlow = false;
    }
    public void Slow()
    {
        currentChoise.currentmodeFast = false;
        currentChoise.currentmodeMedium = false;
        currentChoise.currentmodeSlow = true;
    }
}
