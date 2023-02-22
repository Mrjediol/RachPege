using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    public void CallTheEndGame()
    {
        if (enemy.health <= 0)
        {
            EndGame endGame = FindObjectOfType<EndGame>();
            endGame.EndTheGame();
        }
    }
}
