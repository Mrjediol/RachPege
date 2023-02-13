using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public bool GameIsPause = false;

    public GameObject pauseMenuUi;
    public AudioMixer musicAudioMixer;
    public float musicVolume;
    public bool isMuted = false;
    public SettingsMenu settingsMenu;
    public bool imMuted = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        isMuted = false;
        if (imMuted)
        {
            Debug.Log("llego estoy muted");
            MuteMusicVolume();
        }
        Debug.Log("hago muted");
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
       
    }

    void Pause()
    {
        isMuted = true;
        MuteMusicVolume();
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void MuteMusicVolume()
    {
        if (isMuted)
        {
            musicAudioMixer.SetFloat("musicVolume", -80f);
        }
        else
        {
            musicAudioMixer.SetFloat("musicVolume", settingsMenu.musicVolume);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}



