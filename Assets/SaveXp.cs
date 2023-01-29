using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveXp : MonoBehaviour
{
    public float Icecurrentxp;
    public int Icelevel;
    public float Firecurrentxp;
    public int Firelevel;

    void Start()
    {
        Icelevel = PlayerPrefs.GetInt("Icelevel", 1);
        Icecurrentxp = PlayerPrefs.GetFloat("Icecurrentxp", 1);
        Firelevel = PlayerPrefs.GetInt("Firelevel", 1);
        Firecurrentxp = PlayerPrefs.GetFloat("Firecurrentxp", 1);
    }
        private void Update()
    {
        PlayerPrefs.SetInt("Icelevel", Icelevel); // guardar el nivel actual
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("Icecurrentxp", Icecurrentxp); // guardar la Experiencia actual
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("Firelevel", Firelevel); // guardar el nivel actual
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("Firecurrentxp", Firecurrentxp); // guardar la Experiencia actual
        PlayerPrefs.Save(); 

    }

}
