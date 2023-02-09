using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveMouseDirectionAuto : MonoBehaviour
{
    public float force = 3f; // fuerza a la que se moverá el objeto
    public float destroyDelay = 1f; //tiempo para destruir el objeto en segundos
    public float delayBetweenShots = 0.1f; //tiempo entre la creacion de cada prefab
    private Transform player; //objeto al que se movera el prefab
    public GameObject prefab;

    void Start()
    {
        player = GameObject.Find("Player").transform; // busca el objeto player
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreatePrefab();
        }
       
    }
    void CreatePrefab()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = player.position.z;
        GameObject instantiatedPrefab = Instantiate(prefab, player.position, Quaternion.identity);
        Rigidbody2D rb = instantiatedPrefab.GetComponent<Rigidbody2D>();
        Vector3 direction = (worldPos - player.position).normalized;
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        Destroy(instantiatedPrefab, destroyDelay);
    }
}