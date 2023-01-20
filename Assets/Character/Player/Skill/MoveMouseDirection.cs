using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveMouseDirection : MonoBehaviour
{
    public float force = 3f; // fuerza a la que se mover� el objeto
    public float destroyDelay = 1f; //tiempo para destruir el objeto en segundos
    private Transform player; //objeto al que se movera el prefab
    public GameObject prefab;
    [SerializeField] private AudioSource Shoot;
    void Start()
    {
        player = GameObject.Find("Player").transform; // busca el objeto player
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot.Play();
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
}