using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class InstantiateOnClickVoid : MonoBehaviour
{

    public GameObject prefab; //asigna el prefab en el inspector
    public float destroyDelay = 10f; //tiempo para destruir el objeto en segundos
    public float manaCost = 50f;
    public float cooldown = 4f;
    public Vector3 scale = new Vector3(1, 1, 1);
    [SerializeField] private AudioSource Shoot;
    //public GameObject prefab;
    public Slider voidCd;
    private float nextFireTime;

    void Start()
    {
        nextFireTime = 0f;
        voidCd = GameObject.Find("voidCd").GetComponent<Slider>();
    }
    void Update()
    {
        if (voidCd.value >= 1.0f)
        {
            voidCd.gameObject.SetActive(false);
        }
        else
        {
            voidCd.gameObject.SetActive(true);
        }
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0)) 
            { 
                ManaSystem manaSystem = FindObjectOfType<ManaSystem>();

                if (manaSystem.currentMana > manaCost)
                {

                    Vector3 mousePos = Input.mousePosition;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                    worldPos.z = 0; // aseguramos que la posición en z sea 0 para evitar problemas con la profundidad de la cámara
                    GameObject instantiatedPrefab = Instantiate(prefab, worldPos, Quaternion.identity);
                    manaSystem.ReduceMana(manaCost);
                    Destroy(instantiatedPrefab, destroyDelay);
                    nextFireTime = Time.time + cooldown;
                }
            }
        }
        voidCd.value = nextFireTime > Time.time ? 1 - (nextFireTime - Time.time) / cooldown : 1;
    }
}