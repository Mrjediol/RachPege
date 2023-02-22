using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsMenu : MonoBehaviour
{
    public GameObject weaponsMenu;
    [SerializeField] private AudioSource WeaponsMenuSound;
    [SerializeField] private AudioSource ExitMenuWeaponsSound;
    Death death;
    PauseMenu pauseMenu;
    FireWeaponChoice fireWeaponChoice;
    LevelSystem levelSystem;
    public bool isMenuActive = false;
    AudioManager audioManager;
    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        death = FindObjectOfType<Death>();
        fireWeaponChoice = FindObjectOfType<FireWeaponChoice>();
        levelSystem = FindObjectOfType<LevelSystem>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pauseMenu.GameIsPause == true || death.isDead == true || fireWeaponChoice.ischoiceMenuActive == true || levelSystem.unlokingActive == true)
                return;
            if (isMenuActive == false)
            {
                audioManager.Play("WeaponsMenuOpen");
                weaponsMenu.SetActive(true);
                isMenuActive = true;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                audioManager.Play("WeaponsMenuClose");
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