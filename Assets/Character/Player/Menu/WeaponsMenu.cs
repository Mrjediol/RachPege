using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsMenu : MonoBehaviour
{
    public GameObject weaponsMenu;
    [SerializeField] private AudioSource WeaponsMenuSound;
    [SerializeField] private AudioSource ExitMenuWeaponsSound;

    public bool isMenuActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isMenuActive == false)
            {
                WeaponsMenuSound.Play();
                weaponsMenu.SetActive(true);
                isMenuActive = true;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                ExitMenuWeaponsSound.Play();
                weaponsMenu.SetActive(false);
                isMenuActive = false;
                
            }
        }
    }
}

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            if(!weaponsMenu.activeSelf)
//        {
//            WeaponsMenuSound.Play();
//            weaponsMenu.SetActive(true);
//        }

//            //WeaponsMenuSound.Play();
//            //weaponsMenu.SetActive(!weaponsMenu.activeSelf);
//        }
//    }
//}