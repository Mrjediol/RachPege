using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveMouseDirectionIce : MonoBehaviour
{
    public int weaponDamage = 5;
    public Vector3 scale = new Vector3(1, 1, 1);
    public float cooldown = 0.5f;
    public float force = 3f; // fuerza a la que se mover� el objeto
    public bool piercing = false;
    public float destroyDelay = 1f; //tiempo para destruir el objeto en segundos
    private Transform player; //objeto al que se movera el prefab
    public GameObject prefab;
    [SerializeField] private AudioSource Shoot;
    
    private float nextFireTime;

    void Start()
    {
        player = GameObject.Find("Player").transform; // busca el objeto player
        nextFireTime = 0f;
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot.Play();
                Vector3 mousePos = Input.mousePosition;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                worldPos.z = player.position.z;
                GameObject instantiatedPrefab = Instantiate(prefab, player.position, Quaternion.identity);
                Rigidbody2D rb = instantiatedPrefab.GetComponent<Rigidbody2D>();
                instantiatedPrefab.transform.parent = transform;
                instantiatedPrefab.transform.localScale = scale;
                instantiatedPrefab.GetComponent<AttackColliderIce>().iceDamage = weaponDamage;
                instantiatedPrefab.GetComponent<AttackColliderIce>().piercing = piercing;
                Vector3 direction = (worldPos - player.position).normalized;
                rb.AddForce(direction * force, ForceMode2D.Impulse);
                Destroy(instantiatedPrefab, destroyDelay);
                nextFireTime = Time.time + cooldown;
            }
        }
    }
}