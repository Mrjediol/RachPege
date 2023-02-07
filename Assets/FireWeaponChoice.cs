using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class FireWeaponChoice : MonoBehaviour
{
    public GameObject choiceMenu;
    // Start is called before the first frame update
    public bool ischoiceMenuActive = false;

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
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            Choice();
        }
    }
}
