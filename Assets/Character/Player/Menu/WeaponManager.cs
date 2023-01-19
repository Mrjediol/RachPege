using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static GameObject currentWeapon;
    public GameObject weaponsMenu;
    public static void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        currentWeapon = weapon;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            weaponsMenu.SetActive(!weaponsMenu.activeSelf);
            Time.timeScale = 0;
        }
    }
}