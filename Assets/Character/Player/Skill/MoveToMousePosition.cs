using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveToMousePosition : MonoBehaviour
{
    public float speed = 3f; // Velocidad a la que se moverá el objeto
    public float destroyDelay = 3f; //tiempo para destruir el objeto en segundos
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
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = player.position.z;
            GameObject instantiatedPrefab = Instantiate(prefab, player.position, Quaternion.identity);
            StartCoroutine(Move(instantiatedPrefab.transform, worldPos, destroyDelay));
        }
    }

    IEnumerator Move(Transform prefab, Vector3 target, float delay)
    {
        float distance = Vector3.Distance(prefab.position, target);
        float currentTime = 0f;
        while (distance > 0.01f)
        {
            prefab.position = Vector3.Lerp(prefab.position, target, currentTime / distance);
            currentTime += Time.deltaTime * speed;
            distance = Vector3.Distance(prefab.position, target);
            yield return null;
        }
        Destroy(prefab.gameObject, delay);
    }
}