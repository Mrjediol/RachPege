using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InstantiateOnClick : MonoBehaviour
{

    public GameObject prefab; //asigna el prefab en el inspector
    public float destroyDelay = 3f; //tiempo para destruir el objeto en segundos

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0; // aseguramos que la posición en z sea 0 para evitar problemas con la profundidad de la cámara
            GameObject instantiatedPrefab = Instantiate(prefab, worldPos, Quaternion.identity);
            Destroy(instantiatedPrefab, destroyDelay);
        }
    }
}