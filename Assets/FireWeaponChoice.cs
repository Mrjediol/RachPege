using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class FireWeaponChoice : MonoBehaviour
{
    public GameObject choiceMenu;
    public GameObject choiceMenuIce;
    // Start is called before the first frame update
    public bool ischoiceMenuActive = false;
    WeaponManager weaponManager;
    private void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
    }
    public void Choice()
    {
        if (ischoiceMenuActive == false)
        {
            choiceMenu.SetActive(true);
            ischoiceMenuActive = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            choiceMenu.SetActive(false);
            ischoiceMenuActive = false;
        }
    }
    public void ChoiceIce()
    {
        if (ischoiceMenuActive == false)
        {
            choiceMenuIce.SetActive(true);
            ischoiceMenuActive = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            choiceMenuIce.SetActive(false);
            ischoiceMenuActive = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            if (Time.timeScale == 0 || weaponManager.currentWeapon == null)
                return;
            if (weaponManager.currentWeapon.name == "IceBall(Clone)")
                ChoiceIce();
            if (weaponManager.currentWeapon.name == "FireBall(Clone)")
                Choice();
        }
    }
}
