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
    public Slider gameVolumeSlider;
    public Slider musicVolumeSlider;

    

    private float gamevolume;
    public float musicVolume;
    public PauseMenu pauseMenu;
    Resolution[] resolutions;
    private void Start()

    {
        // Cargar el valor guardado en PlayerPrefs
        float savedGameVolume = PlayerPrefs.GetFloat("gameVolume", 1f);

        // Configurar el AudioMixer con el valor cargado
        gameAudioMixer.SetFloat("volume", savedGameVolume);
        gamevolume = savedGameVolume;
        gameVolumeSlider.value = savedGameVolume;
        LoadGameMutedState();

        float savedMusicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);

        // Configurar el AudioMixer con el valor cargado
        musicAudioMixer.SetFloat("musicVolume", savedMusicVolume);
        musicVolume = savedMusicVolume;
        musicVolumeSlider.value = savedMusicVolume;
        LoadMusicMutedState();

        //gameAudioMixer.GetFloat("volume", out gamevolume);
        //musicAudioMixer.GetFloat("musicVolume", out musicVolume);
        //musicVolume = 0;
        gameToggle.onValueChanged.AddListener(MuteGameVolume);
        musicToggle.onValueChanged.AddListener(MuteMusicVolume);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
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
        //gameToggle.isOn = (gamevolume != -80f);
        //musicToggle.isOn = (musicVolume != -80f);
    }
   
    public void SetVolumeMusic(float volume)
    {
        musicAudioMixer.SetFloat("musicVolume", volume);
        musicVolume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume); // Guardar el valor en PlayerPrefs
        PlayerPrefs.Save();

    }

   
    private void LoadMusicMutedState()
    {
        int isMuted = PlayerPrefs.GetInt("musicMuted", 0);
        bool musicIsMuted = (isMuted == 1);

        musicToggle.isOn = musicIsMuted;
        MuteMusicVolume(musicIsMuted);
    }
    private void LoadGameMutedState()
    {
        int gisMuted = PlayerPrefs.GetInt("gameMuted", 0);
        bool gameIsMuted = (gisMuted == 1);

        gameToggle.isOn = gameIsMuted;
        MuteGameVolume(gameIsMuted);
    }
    public void SetVolume(float volume)
    {
        gameAudioMixer.SetFloat("volume", volume);
        gamevolume = volume;
        PlayerPrefs.SetFloat("gameVolume", volume); // Guardar el valor en PlayerPrefs
        PlayerPrefs.Save();
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
        PlayerPrefs.SetInt("gameMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void MuteMusicVolume(bool isMuted)
    {

        if (!isMuted)
        {
            musicAudioMixer.SetFloat("musicVolume", -80f);
            if (pauseMenu)
                pauseMenu.imMuted = false;
        }
        else
        {
            musicAudioMixer.SetFloat("musicVolume", musicVolume);
            if (pauseMenu)
                pauseMenu.imMuted = true;
        }
        PlayerPrefs.SetInt("musicMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
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