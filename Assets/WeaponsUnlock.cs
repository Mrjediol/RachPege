using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponsUnlock : MonoBehaviour
{
    LevelRequired levelRequired;
    LevelSystem levelSystem;

    public bool fireunLocked;
    public bool IceunLocked;
    public bool BlastunLocked;
    public bool VoidunLocked;
    public bool RayunLocked;
    public bool AniquilationunLocked;

    public GameObject fireWeapon;
    public GameObject iceWeapon;
    public GameObject rayWeapon;
    public GameObject voidWeapon;
    public GameObject blastWeapon;
    public GameObject AniquilationWeapon;
    public GameObject weaponExplication;
    public GameObject AniquilationExplication;

    public Image image;
    public GameObject canvasUnlocked;
    public TextMeshProUGUI unlockedText;
    private void Start()
    {
        levelRequired = GetComponent<LevelRequired>();
        levelSystem = FindObjectOfType<LevelSystem>();
        if (levelSystem.level >= levelRequired.fireLevelRequired)
        {
            fireWeapon.SetActive(true);
            fireunLocked = true;
        }
        if (levelSystem.level >= levelRequired.IceLevelRequired)
        { 
            iceWeapon.SetActive(true);
            IceunLocked = true;
        }
        if (levelSystem.level >= levelRequired.RayLevelRequired)
        {
            rayWeapon.SetActive(true);
            RayunLocked = true;
        }
        if (levelSystem.level >= levelRequired.BlastLevelRequired)
        {
            blastWeapon.SetActive(true);
            BlastunLocked = true;
        }
        if (levelSystem.level >= levelRequired.VoidLevelRequired)
        {
            voidWeapon.SetActive(true);
            VoidunLocked = true;
        }
        if (levelSystem.level >= levelRequired.AniquilationLevelRequired)
        {
            AniquilationWeapon.SetActive(true);
            AniquilationunLocked = true;
        }
    }


    private void Update()
    {
        if (levelSystem.level >= levelRequired.fireLevelRequired && fireunLocked == false)
        {
            CanvasActiver("Fire", fireWeapon,ref fireunLocked);
            weaponExplication.SetActive(true);
        }
        if (levelSystem.level >= levelRequired.IceLevelRequired && IceunLocked == false)
        {
            CanvasActiver("Ice", iceWeapon,ref IceunLocked);
        }
        if (levelSystem.level >= levelRequired.RayLevelRequired && RayunLocked == false)
        {
            CanvasActiver("Ray", rayWeapon,ref RayunLocked);
        }
        if (levelSystem.level >= levelRequired.BlastLevelRequired && BlastunLocked == false)
        {
            CanvasActiver("Blast", blastWeapon,ref BlastunLocked);
        }
        if (levelSystem.level >= levelRequired.VoidLevelRequired && VoidunLocked == false)
        {
            CanvasActiver("Void", voidWeapon,ref VoidunLocked);
        }
        if (levelSystem.level >= levelRequired.AniquilationLevelRequired && AniquilationunLocked == false)
        {
            CanvasActiver("Aniquilation" , AniquilationWeapon,ref AniquilationunLocked);
            AniquilationExplication.SetActive(true);
        }
    }

    public void CanvasActiver(string weapon, GameObject name,ref bool locked)
    {
        name.SetActive(true);
        locked = true;
        Time.timeScale = 0f;
        canvasUnlocked.SetActive(true);
        levelSystem.unlokingActive = true;
        StartCoroutine(DeactivateCanvasAfterDelay(30f));
        unlockedText.text = "You Unlocked " + weapon + " Weapon";
        Sprite Sprite = Resources.Load<Sprite>(weapon);
        image.sprite = Sprite;
    }
    public IEnumerator DeactivateCanvasAfterDelay(float delay)
    {
        if (levelSystem.unlokingActive == true)
        {
            yield return new WaitForSecondsRealtime(delay);
            Desactivate();
        }
    }
    public void Desactivate()
    {
        canvasUnlocked.SetActive(false);
        Time.timeScale = 1f;
        levelSystem.unlokingActive = false;
    }
}
