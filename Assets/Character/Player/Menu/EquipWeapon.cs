using UnityEngine;
using UnityEngine.UI;

public class EquipWeapon : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform weaponHold;
    public GameObject weaponsMenu;
    public GameObject WeaponIMG;
    //public static GameObject currentWPIMG;
    [SerializeField] private AudioSource ExitMenuWeaponsSound;
    WeaponsMenu weaponsmenu;
    public void Equip()
    {
        //WeaponIMG.SetActive(true);
        Debug.Log("equip se ejecuta");
        ExitMenuWeaponsSound.Play();
        GameObject weapon = Instantiate(weaponPrefab, weaponHold.position, weaponHold.rotation);
        weapon.transform.parent = weaponHold;
        WeaponManager.EquipWeapon(weapon);
        
        Time.timeScale = 1;
        weaponsMenu.SetActive(false);
        WeaponsMenu wm = FindObjectOfType<WeaponsMenu>();
        wm.isMenuActive = false;

        //if (currentWPIMG.activeInHierarchy)
        //{
        //    currentWPIMG.SetActive(false);
        //}

        //currentWPIMG = WeaponIMG;
        //currentWPIMG.SetActive(false);
    }
    
}