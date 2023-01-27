using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public GameObject currentWeapon;
    public GameObject previousWeapon;
    public Transform currentWeaponHold;
    public Transform previousWeaponHold;
    public GameObject weaponsMenu;
    public Sprite mySprite;

    public GameObject currentfireballBook;
    public GameObject currentplantballBook;
    public GameObject currenticeballBook;
    public GameObject previuosFire;
    public GameObject previuosPlant;
    public GameObject previousIce;
    public GameObject IceXpBar;
    public GameObject IceLevel;
    public GameObject FireXpBar;
    public GameObject FireLevel;
    public Slider iceCd;

    private void Start()
    {
      

    }
    public void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            if (currentWeapon.name != weapon.name)
            {
                Debug.Log("no se repiten asique te la añado");
                Destroy(previousWeapon);
                previousWeapon = currentWeapon;
                currentWeapon = weapon;
                previousWeapon.transform.parent = previousWeaponHold;
                if (previousWeapon != null && previousWeapon.name == "FireBall(Clone)")
                {
                    previousWeapon.GetComponent<MoveMouseDirectionFire>().enabled = false;
                }
                if (previousWeapon !=null && previousWeapon.name == "IceBall(Clone)")
                {
                    previousWeapon.GetComponent<MoveMouseDirectionIce>().enabled = false;
                }
                UiUpdate();

            }
            else
            {
                Debug.Log("no equipes dos veces la misma anda");
                Destroy(currentWeapon);
                currentWeapon = weapon;
                if (currentWeapon.name == "IceBall(Clone)")
                {
                    currentWeapon.GetComponent<MoveMouseDirectionIce>().enabled = true;
                    currenticeballBook.SetActive(true);
                    IceXpBar.SetActive(true);
                    IceLevel.SetActive(true);
                    SaveXp savexp = FindObjectOfType<SaveXp>();
                    WeaponLevelIce weaponlevelIce = FindObjectOfType<WeaponLevelIce>();
                    weaponlevelIce.level = savexp.Icelevel;
                    weaponlevelIce.currentXp = savexp.Icecurrentxp;
                    iceCd.gameObject.SetActive(true);

                }
                if (currentWeapon.name == "FireBall(Clone)")
                {
                    currentWeapon.GetComponent<MoveMouseDirectionFire>().enabled = true;
                    currentfireballBook.SetActive(true);
                    FireXpBar.SetActive(true);
                    FireLevel.SetActive(true);
                    SaveXp savexp = FindObjectOfType<SaveXp>();
                    WeaponLevelFire weaponlevelFire = FindObjectOfType<WeaponLevelFire>();
                    weaponlevelFire.level = savexp.Firelevel;
                    weaponlevelFire.currentXp = savexp.Firecurrentxp;

                }
                return;
                
            }
        }
        else
        {
            Debug.Log("solo deberia pasar si no tengo arma en currentweapon");
            
            currentWeapon = weapon;
        }
        currentWeapon.transform.parent = currentWeaponHold;
        

        if (currentWeapon.name == "FireBall(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionFire>().enabled = true;
            currentfireballBook.SetActive(true);
            FireXpBar.SetActive(true);
            FireLevel.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelFire weaponlevelFire = FindObjectOfType<WeaponLevelFire>();
            weaponlevelFire.level = savexp.Firelevel;
            weaponlevelFire.currentXp = savexp.Firecurrentxp;
        }
        if (currentWeapon.name == "IceBall(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionIce>().enabled = true;
            currenticeballBook.SetActive(true);
            IceXpBar.SetActive(true);
            IceLevel.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelIce weaponlevelIce = FindObjectOfType<WeaponLevelIce>();
            weaponlevelIce.level = savexp.Icelevel;
            weaponlevelIce.currentXp = savexp.Icecurrentxp;
            iceCd.gameObject.SetActive(true);
        }

    }

    void UiUpdate()
    {
        if(currentWeapon.name == "FireBall(Clone)")
        {
            currentfireballBook.SetActive(true);
            FireXpBar.SetActive(true);
            FireLevel.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelFire weaponlevelFire = FindObjectOfType<WeaponLevelFire>();
            weaponlevelFire.level = savexp.Firelevel;
            weaponlevelFire.currentXp = savexp.Firecurrentxp;
        }
        else
        {
            currentfireballBook.SetActive(false);
            FireXpBar.SetActive(false);
            FireLevel.SetActive(false);
        }
        if (currentWeapon.name == "IceBall(Clone)")
        {
            currenticeballBook.SetActive(true);
            IceXpBar.SetActive(true);
            IceLevel.SetActive(true);
            SaveXp savexp = FindObjectOfType<SaveXp>();
            WeaponLevelIce weaponlevelIce = FindObjectOfType<WeaponLevelIce>();
            weaponlevelIce.level = savexp.Icelevel;
            weaponlevelIce.currentXp = savexp.Icecurrentxp;
            
        }
        else
        {
            currenticeballBook.SetActive(false);
            IceXpBar.SetActive(false);
            IceLevel.SetActive(false);
            iceCd.gameObject.SetActive(false);
        }
        if (currentWeapon.name == "PlantBall(Clone)")
        {
            currentplantballBook.SetActive(true);
        }
        else
        {
            currentplantballBook.SetActive(false);
        }
        if (previousWeapon.name == "FireBall(Clone)")
        {
            previuosFire.SetActive(true);
        }
        else
        {
            previuosFire.SetActive(false);
        }
        if (previousWeapon.name == "IceBall(Clone)")
        {
            previousIce.SetActive(true);
        }
        else
        {
            previousIce.SetActive(false);
        }
        if (previousWeapon.name == "PlantBall(Clone)")
        {
            previuosPlant.SetActive(true);
        }
        else
        {
            previuosPlant.SetActive(false);
        }
    }
    void SwitchWeapon()
    {
        GameObject temp = currentWeapon;
        currentWeapon = previousWeapon;
        previousWeapon = temp;
        currentWeapon.transform.parent = currentWeaponHold;
        if (currentWeapon.name == "FireBall(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionFire>().enabled = true;
        }
        if (currentWeapon.name == "IceBall(Clone)")
        {
            currentWeapon.GetComponent<MoveMouseDirectionIce>().enabled = true;
        }


        previousWeapon.transform.parent = previousWeaponHold;
        if (previousWeapon.name == "FireBall(Clone)")
        {
            previousWeapon.GetComponent<MoveMouseDirectionFire>().enabled = false;
        }
        if (previousWeapon.name == "IceBall(Clone)")
        {
            previousWeapon.GetComponent<MoveMouseDirectionIce>().enabled = false;
        }

        UiUpdate();
    }
    void Update()
    {


        if (currentWeapon != null)
        {
            if (currentWeapon.name == "IceBall(Clone)")
            {
                SaveXp savexp = FindObjectOfType<SaveXp>();
                WeaponLevelIce weaponlevelIce = FindObjectOfType<WeaponLevelIce>();
                savexp.Icelevel = weaponlevelIce.level;
                savexp.Icecurrentxp = weaponlevelIce.currentXp;
            }
            if(currentWeapon.name == "FireBall(Clone)")
            {
                SaveXp saveXp = FindObjectOfType<SaveXp>();
                WeaponLevelFire weaponLevelFire = FindObjectOfType<WeaponLevelFire>();
                saveXp.Firelevel = weaponLevelFire.level;
                saveXp.Firecurrentxp = weaponLevelFire.currentXp;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && previousWeapon != null)
        {
            SwitchWeapon();
        }
    }
}

//public class WeaponManager : MonoBehaviour
//{
//    public static GameObject currentWeapon;
//    public GameObject weaponsMenu;
//    public static void EquipWeapon(GameObject weapon)
//    {
//        if (currentWeapon != null)
//        {
//            Destroy(currentWeapon);
//        }

//        currentWeapon = weapon;
//    }

//}
//void Update()
//{
//    if (Input.GetKeyDown(KeyCode.E))
//    {
//        weaponsMenu.SetActive(!weaponsMenu.activeSelf);
//        Time.timeScale = 0;
//    }
//}