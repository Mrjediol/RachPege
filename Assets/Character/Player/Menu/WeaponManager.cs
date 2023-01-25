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
    public void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            if (currentWeapon.name != weapon.name)
            {
                Debug.Log("no se repiten asique te la a�ado");
                Destroy(previousWeapon);
                previousWeapon = currentWeapon;
                currentWeapon = weapon;
                previousWeapon.transform.parent = previousWeaponHold;
                previousWeapon.GetComponent<MoveMouseDirection>().enabled = false;
                UiUpdate();

            }
            else
            {
                Debug.Log("no equipes dos veces la misma anda");
                Destroy(currentWeapon);
                currentWeapon = weapon;
                return;
                
            }
        }
        else
        {
            Debug.Log("solo deberia pasar si no tengo arma en currentweapon");
            
            currentWeapon = weapon;
        }
        currentWeapon.transform.parent = currentWeaponHold;
        currentWeapon.GetComponent<MoveMouseDirection>().enabled = true;

        if (currentWeapon.name == "FireBall(Clone)")
        {
            currentfireballBook.SetActive(true);
        }
        if (currentWeapon.name == "IceBall(Clone)")
        {
            currenticeballBook.SetActive(true);
        }

    }

    void UiUpdate()
    {
        if(currentWeapon.name == "FireBall(Clone)")
        {
            currentfireballBook.SetActive(true);
        }
        else
        {
            currentfireballBook.SetActive(false);
        }
        if (currentWeapon.name == "IceBall(Clone)")
        {
            currenticeballBook.SetActive(true);
        }
        else
        {
            currenticeballBook.SetActive(false);
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
        currentWeapon.GetComponent<MoveMouseDirection>().enabled = true;

        previousWeapon.transform.parent = previousWeaponHold;
        previousWeapon.GetComponent<MoveMouseDirection>().enabled = false;
        UiUpdate();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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