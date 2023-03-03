using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerInmune : MonoBehaviour
{
    ImImune imImune;
    private bool hasPlayer;
    AudioManager audioManager;
    private void Start()
    {
        imImune = FindObjectOfType<ImImune>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasPlayer)
            return;
        if (collision.CompareTag("Fireball") || collision.CompareTag("Iceball"))
        {
            imImune.InmuneShow(collision);
            Time.timeScale = 0f;
            hasPlayer = true;
        }
    }
}
