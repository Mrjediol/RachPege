using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer gameAudioMixer;
    public AudioMixer musicAudioMixer;

    public TMP_Dropdown resolutionDropdown;

    public Toggle gameToggle;
    public Toggle musicToggle;
    
    private float gamevolume;
    public float musicVolume;
    public PauseMenu pauseMenu;
    Resolution[] resolutions;
    private void Start()

    {

        gameAudioMixer.GetFloat("volume", out gamevolume);
        musicAudioMixer.GetFloat("musicVolume", out musicVolume);
        musicVolume = 0;
        gameToggle.onValueChanged.AddListener(MuteGameVolume);
        musicToggle.onValueChanged.AddListener(MuteMusicVolume);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
   
    public void SetVolumeMusic(float volume)
    {
        musicAudioMixer.SetFloat("musicVolume", volume);
        musicVolume = volume;
    }

    public void MuteMusicVolume(bool isMuted)
    {
        
        if (!isMuted)
        {
            musicAudioMixer.SetFloat("musicVolume", -80f);
            pauseMenu.imMuted = false;
        }
        else
        {
            musicAudioMixer.SetFloat("musicVolume", musicVolume);
            pauseMenu.imMuted = true;
        }
    }
    public void SetVolume(float volume)
    {
        gameAudioMixer.SetFloat("volume", volume);
        gamevolume = volume;
    }

    public void MuteGameVolume(bool isMuted)
    {
        if (!isMuted)
            
        {
            gameAudioMixer.SetFloat("volume", -80f);
        }
        else
        {
            gameAudioMixer.SetFloat("volume", gamevolume);
        }
    }

    
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void DeleteProgres(string nextScene)
    {
        PlayerPrefs.DeleteAll();
        pauseMenu.Resume();
        Veil.instance.LoadScene(nextScene);
        
    }

}
//Process.Start(Application.dataPath.Replace("_Data", ".exe"));
//Application.Quit();
//SceneManager.LoadScene("Menu");