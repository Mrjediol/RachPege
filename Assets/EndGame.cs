using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndGame : MonoBehaviour
{
    public GameObject endGameScreem;
    public TextMeshProUGUI tiempoTranscurridoText;
    public GameObject scoreGameobject;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI CurrentTimeText;
    public int Score;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float timeElapsed = Time.timeSinceLevelLoad;
        int hours = (int)(timeElapsed / 3600);
        int minutes = (int)((timeElapsed % 3600) / 60);
        int seconds = (int)(timeElapsed % 60);
        string timeText = string.Format("Time Survived : {0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        CurrentTimeText.text = timeText;
    }
    public void AddToScore(int scoreValue)
    {
      
        Score += scoreValue;
        ScoreText.text = "Current Score :" + Score;
       

        // Crear una cadena de texto con el tiempo transcurrido
        
    }
    public void EndTheGame()
    {
        SaveXp saveXp = FindObjectOfType<SaveXp>();
        saveXp.postGame = true;
        // Obtener el tiempo transcurrido en segundos
        float timeElapsed = Time.timeSinceLevelLoad;
        Time.timeScale = 0F;
        Score = 0;
        scoreGameobject.SetActive(true);
        // Calcular las horas, minutos y segundos transcurridos
        int hours = (int)(timeElapsed / 3600);
        int minutes = (int)((timeElapsed % 3600) / 60);
        int seconds = (int)(timeElapsed % 60);
        LevelSystem levelSystem = FindObjectOfType<LevelSystem>();
        levelSystem.level = 50;
        saveXp.Firelevel = 5;
        saveXp.Icelevel = 5;
        saveXp.Raylevel = 5;
        saveXp.Voidlevel = 5;
        saveXp.Aniquilationlevel = 5;
        saveXp.Blastlevel = 5;
        saveXp.SaveAllLevels();
        levelSystem.LevelUp();
        // Crear una cadena de texto con el tiempo transcurrido
        string timeText = string.Format("Your Final Time is : {0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        // Mostrar el tiempo transcurrido en un objeto de texto
        tiempoTranscurridoText.text = timeText;

        // Mostrar la pantalla de fin de juego
        endGameScreem.SetActive(true);
    }

    public void GoToArena()
    {
        player.transform.position = new Vector3(58.448f, -11.918f, 0);
        Time.timeScale = 1f;
        endGameScreem.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
