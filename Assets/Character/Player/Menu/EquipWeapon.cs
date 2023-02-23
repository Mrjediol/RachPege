using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform weaponHold;
    public GameObject weaponsMenu;
    //public GameObject WeaponIMG;

    public WeaponManager weaponManager;
    AudioManager audioManager;
    public void Equip()
    {
        //WeaponIMG.SetActive(true);
        Debug.Log("equip se ejecuta");
        GameObject weapon = Instantiate(weaponPrefab, weaponHold.position, weaponHold.rotation);

        weaponManager.EquipWeapon(weapon);
        weapon.transform.parent = weaponHold;
        Time.timeScale = 1;
        weaponsMenu.SetActive(false);
        WeaponsMenu wm = FindObjectOfType<WeaponsMenu>();
        wm.isMenuActive = false;

        
    }

    //if (currentWPIMG.activeInHierarchy)
    //{
    //    currentWPIMG.SetActive(false);
    //}

    //currentWPIMG = WeaponIMG;
}