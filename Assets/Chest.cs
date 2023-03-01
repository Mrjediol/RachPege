using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public float activationDistance = 0.5f;
    public KeyCode activationKey = KeyCode.T;
    public GameObject chest;
    public int giveXP = 1000;
    private bool canOpen = false;
    public GameObject OpenEffect;
    public Vector3 scale = new(0.2f, 0.2f, 0.2f);
    private void Start()
    {
        if (chest == null)
        {
            chest = gameObject;
        }
        OpenEffect = Resources.Load<GameObject>("Chest");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("CanOpenTrue");
            canOpen = true;
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {

    //    Debug.Log("CanOpenTrue");
    //    canOpen = true;
    //    }
    //}
  
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("false");
            canOpen = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(activationKey) && canOpen)
        {
            Debug.Log("deberia abrirse");
            chest.GetComponent<Animator>().SetTrigger("Open");
           
        }
    }

    public void RemoveAndGiveXp()
    {
        GameObject effect = Instantiate(OpenEffect, transform.position, Quaternion.identity);
        effect.transform.localScale = scale;
        effect.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        ParticleSystem ps = effect.GetComponent<ParticleSystem>();
        Renderer psRenderer = ps.GetComponent<Renderer>();
        psRenderer.sortingOrder = 11;
        psRenderer.sortingLayerName = "arboles";
        FindObjectOfType<AudioManager>().Play("OpenChest");
        LevelSystem XP = FindObjectOfType<LevelSystem>();
        XP.GainExperience(giveXP);
        Destroy(gameObject);
    }
}
