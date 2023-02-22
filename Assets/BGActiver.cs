using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGActiver : MonoBehaviour
{
    // Start is called before the first frame update

    AudioManager audioManager;
    public string SoundToPlay;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        audioManager.Play(SoundToPlay);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            audioManager.Stop(SoundToPlay);
    }
}
