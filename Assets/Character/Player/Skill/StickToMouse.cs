using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StickToMouse : MonoBehaviour
{
    public GameObject prefab; //asigna el prefab en el inspector
    public float speed = 3f; // Velocidad a la que se moverá el objeto
    public float destroyDelay = 3f; //tiempo para destruir el objeto en segundos
    private Transform player; //objeto al que se movera el prefab
    private GameObject instantiatedPrefab;

    void Start()
    {
        player = GameObject.Find("Player").transform; // busca el objeto player
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            instantiatedPrefab = Instantiate(prefab, player.position, Quaternion.identity);
            Destroy(instantiatedPrefab, destroyDelay);
        }
        if (instantiatedPrefab != null)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = instantiatedPrefab.transform.position.z;
            instantiatedPrefab.transform.position = Vector3.MoveTowards(instantiatedPrefab.transform.position, worldPos, speed * Time.deltaTime);
        }
    }
}