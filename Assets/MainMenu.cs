using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenGame(string nextScene)
    {
        Veil.instance.LoadScene(nextScene);
    }
}

