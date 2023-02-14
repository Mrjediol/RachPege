using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeTimeScale : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.jKey.isPressed)
        {
            Time.timeScale = 0.02f;
        }
        else if (Keyboard.current.kKey.isPressed)
        {
            Time.timeScale = 1f;
        }
        else if (Keyboard.current.lKey.isPressed)
        {
            Time.timeScale = 3f;
        }
    }
}
