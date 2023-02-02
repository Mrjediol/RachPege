using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveXp : MonoBehaviour
{
    public float Icecurrentxp;
    public int Icelevel;
    public float Firecurrentxp;
    public int Firelevel;
    public float Voidcurrentxp;
    public int Voidlevel;

    void Start()
    {
        Icelevel = PlayerPrefs.GetInt("Icelevel", 1);
        Icecurrentxp = PlayerPrefs.GetFloat("Icecurrentxp", 1);
        Firelevel = PlayerPrefs.GetInt("Firelevel", 1);
        Firecurrentxp = PlayerPrefs.GetFloat("Firecurrentxp", 1);
        Voidlevel = PlayerPrefs.GetInt("Voidlevel", 1);
        Voidcurrentxp = PlayerPrefs.GetFloat("Voidcurrentxp", 1);
    }
   
    public void SaveIceLevel()
    {
        PlayerPrefs.SetInt("Icelevel", Icelevel); // guardar el nivel actual
        PlayerPrefs.Save();
    }
    public void SaveIceXp()
    {
        PlayerPrefs.SetFloat("Icecurrentxp", Icecurrentxp); // guardar la Experiencia actual
        PlayerPrefs.Save();
    }
    public void SaveFireLevel()
    {
        PlayerPrefs.SetInt("Firelevel", Firelevel); // guardar el nivel actual
        PlayerPrefs.Save();
    }
    public void SaveFireXp()
    {
        PlayerPrefs.SetFloat("Firecurrentxp", Firecurrentxp); // guardar la Experiencia actual
        PlayerPrefs.Save();
    }
    public void SaveVoidLevel()
    {
        PlayerPrefs.SetInt("Voidlevel", Voidlevel); // guardar el nivel actual
        PlayerPrefs.Save();
    }
    public void SaveVoidXp()
    {
        PlayerPrefs.SetFloat("Voidcurrentxp", Voidcurrentxp); // guardar la Experiencia actual
        PlayerPrefs.Save();
    }

}
