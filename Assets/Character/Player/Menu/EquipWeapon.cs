using UnityEngine;
using UnityEngine.UI;

public class EquipWeapon : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform weaponHold;
    public GameObject weaponsMenu;

    public void Equip()
    {
        GameObject weapon = Instantiate(weaponPrefab, weaponHold.position, weaponHold.rotation);
        weapon.transform.parent = weaponHold;
        WeaponManager.EquipWeapon(weapon);
        weaponsMenu.SetActive(false);
    }
}