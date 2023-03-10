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
    public float Raycurrentxp;
    public int Raylevel;
    public float Blastcurrentxp;
    public int Blastlevel;
    public float Aniquilationcurrentxp;
    public int Aniquilationlevel;
    public bool postGame;

    void Start()
    {
        Icelevel = PlayerPrefs.GetInt("Icelevel", 1);
        Icecurrentxp = PlayerPrefs.GetFloat("Icecurrentxp", 1);
        Aniquilationlevel = PlayerPrefs.GetInt("Aniquilationlevel", 1);
        Aniquilationcurrentxp = PlayerPrefs.GetFloat("Aniquilationcurrentxp", 1);
        Firelevel = PlayerPrefs.GetInt("Firelevel", 1);
        Firecurrentxp = PlayerPrefs.GetFloat("Firecurrentxp", 1);
        Voidlevel = PlayerPrefs.GetInt("Voidlevel", 1);
        Voidcurrentxp = PlayerPrefs.GetFloat("Voidcurrentxp", 1);
        Raylevel = PlayerPrefs.GetInt("Raylevel", 1);
        Raycurrentxp = PlayerPrefs.GetFloat("Raycurrentxp", 1);
        Blastlevel = PlayerPrefs.GetInt("Blastlevel", 1);
        Blastcurrentxp = PlayerPrefs.GetFloat("Blastcurrentxp", 1);
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
    public void SaveAniquilationLevel()
    {
        PlayerPrefs.SetInt("Aniquilationlevel", Aniquilationlevel); // guardar el nivel actual
        PlayerPrefs.Save();
    }
    public void SaveAniquilationXp()
    {
        PlayerPrefs.SetFloat("Aniquilationcurrentxp", Aniquilationcurrentxp); // guardar la Experiencia actual
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
    public void SaveBlastLevel()
    {
        PlayerPrefs.SetInt("Blastlevel", Blastlevel); // guardar el nivel actual
        PlayerPrefs.Save();
    }
    public void SaveBlastXp()
    {
        PlayerPrefs.SetFloat("Blastcurrentxp", Blastcurrentxp); // guardar la Experiencia actual
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
    public void SaveRayLevel()
    {
        PlayerPrefs.SetInt("Raylevel", Raylevel); // guardar el nivel actual
        PlayerPrefs.Save();
    }
    public void SaveRayXp()
    {
        PlayerPrefs.SetFloat("Raycurrentxp", Raycurrentxp); // guardar la Experiencia actual
        PlayerPrefs.Save();
    }
    public void SaveAllLevels()
    {
        PlayerPrefs.SetInt("Raylevel", Raylevel); // guardar el nivel actual
        PlayerPrefs.SetInt("Voidlevel", Voidlevel); // guardar el nivel actual
        PlayerPrefs.SetInt("Blastlevel", Blastlevel); // guardar el nivel actual
        PlayerPrefs.SetInt("Firelevel", Firelevel); // guardar el nivel actual
        PlayerPrefs.SetInt("Aniquilationlevel", Aniquilationlevel); // guardar el nivel actual
        PlayerPrefs.SetInt("Icelevel", Icelevel); // guardar el nivel actual
        PlayerPrefs.Save();
    }
}
