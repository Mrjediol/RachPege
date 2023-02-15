using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class InstantiateAniquilation : MonoBehaviour
{

    public GameObject prefab; //asigna el prefab en el inspector
    public GameObject additionalPrefab;
    public float manaCost = 100f;
    public float cooldown = 1f;
    public float destroyDelay = 0.6f; //tiempo para destruir el objeto en segundos
    public Vector3 scale = new Vector3(0.3f, 0.3f, 0.3f);
    public float limit = 5f;
    [SerializeField] private AudioSource Shoot;
    ////public GameObject prefab;
    private bool firstClick = true;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private float nextFireTime;
    private float elapsedTime = 0f;
    public Slider blastCd;
    CurrentCd currentCd;
    PlayerController player;
    GameObject instantiatedAdditionalPrefab;
    void Start()
    {
        //blastCd = GameObject.Find("blastCd").GetComponent<Slider>();
        //nextFireTime = 0f;
        //currentCd = GetComponentInParent<CurrentCd>();
        //nextFireTime = currentCd.fireBlastCd;
        initialPosition = Vector3.zero;
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            if (firstClick)
            {
                initialPosition = player.transform.position;

                // Instancia el prefab adicional en la posición del jugador
                instantiatedAdditionalPrefab = Instantiate(additionalPrefab, initialPosition, Quaternion.identity);
                instantiatedAdditionalPrefab.transform.parent = transform;
                instantiatedAdditionalPrefab.transform.localScale = scale;
                Destroy(instantiatedAdditionalPrefab, limit);
                Invoke("Explotion", limit);

                firstClick = false;
                elapsedTime = 0f;
            }
            else
            {
                Explotion();
            }
        }
    }
    public void Explotion()
    {
        if (firstClick)
            return;
        Debug.Log("llego a 1");
        if (initialPosition != null) // Si la posición inicial se ha registrado y el prefab adicional ha sido destruido
        {
            Debug.Log("llego a 2");
            finalPosition = player.transform.position;

            // Verifica la distancia entre las posiciones inicial y final
            float distance = Vector3.Distance(initialPosition, finalPosition);
            if (distance >= 0.25f) // Si la distancia es mayor o igual a 0.25, instanciar los prefabs
            {
                ManaSystem manaSystem = FindObjectOfType<ManaSystem>();
                Debug.Log("llego a 3");
                if (manaSystem.currentMana > manaCost)
                {
                    // Calcula la cantidad de prefabs a instanciar
                    int numPrefabs = Mathf.CeilToInt(distance / 0.25f); // Redondea hacia arriba para asegurarse de que se instancien suficientes prefabs
                    Destroy(instantiatedAdditionalPrefab);
                    // Calcula la dirección y la distancia entre cada prefab
                    Vector3 direction = (finalPosition - initialPosition).normalized;
                    float step = distance / (numPrefabs - 1);

                    // Instancia los prefabs
                    for (int i = 0; i < numPrefabs; i++)
                    {
                        Vector3 position = initialPosition + direction * step * i;
                        GameObject instantiatedPrefab = Instantiate(prefab, position, Quaternion.identity);
                        instantiatedPrefab.transform.parent = transform;
                        instantiatedPrefab.transform.localScale = scale;
                        Destroy(instantiatedPrefab, destroyDelay);
                    }

                    manaSystem.ReduceMana(manaCost);
                    initialPosition = Vector3.zero; // Resetea la posición inicial para que se registre la siguiente vez que se pulse el botón del mouse
                    firstClick = true;
                    nextFireTime = Time.time + cooldown;
                    elapsedTime = 0f;
                }
            }
        }
    } 
}

//currentCd.fireBlastCd = nextFireTime;
//if (blastCd.value >= 1.0f)
//{
//    blastCd.gameObject.SetActive(false);
//}
//else
//{
//    blastCd.gameObject.SetActive(true);
//}
//if (Time.time > nextFireTime)
//{