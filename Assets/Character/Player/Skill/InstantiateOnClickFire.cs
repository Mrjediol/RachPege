using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class InstantiateOnClickFire : MonoBehaviour
{

    public GameObject prefab; //asigna el prefab en el inspector
    public float destroyDelay = 10f; //tiempo para destruir el objeto en segundos
    public float manaCost = 100f;
    public float cooldown = 20f;
    public Vector3 scale = new Vector3(1, 1, 1);
    [SerializeField] private AudioSource Shoot;
    ////public GameObject prefab;
    public Slider blastCd;
    private float nextFireTime;
    WeaponsMenu weaponsMenu;
    void Start()
    {
        blastCd = GameObject.Find("blastCd").GetComponent<Slider>();
        nextFireTime = 0f;
        weaponsMenu = FindObjectOfType<WeaponsMenu>();
    }
    void Update()
    {
        if (weaponsMenu.isMenuActive == true)
            return;
        if (blastCd.value >= 1.0f)
        {
            blastCd.gameObject.SetActive(false);
        }
        else
        {
            blastCd.gameObject.SetActive(true);
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
                    instantiatedPrefab.transform.parent = transform;
                    Destroy(instantiatedPrefab, destroyDelay);
                    nextFireTime = Time.time + cooldown;
                }
            }
        }
        blastCd.value = nextFireTime > Time.time ? 1 - (nextFireTime - Time.time) / cooldown : 1;
    }
}