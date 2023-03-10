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
    public float range = 0.5f;
    private LineRenderer lineRenderer;
    PlayerController player;
    public GameObject line;
    public LayerMask terrainLayer;
    CurrentCd currentCd;
    Death death;
    AudioManager audioManager;
    void Start()
    {
        nextFireTime = 0f;
        voidCd = GameObject.Find("voidCd").GetComponent<Slider>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        player = FindObjectOfType<PlayerController>();
        currentCd = GetComponentInParent<CurrentCd>();
        nextFireTime = currentCd.voidCd;
        death = FindObjectOfType<Death>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (Time.timeScale == 0 || death.isDead == true)
            return;
        currentCd.voidCd = nextFireTime;
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
                    worldPos.z = 0; // aseguramos que la posici?n en z sea 0 para evitar problemas con la profundidad de la c?mara

                    float distance = Vector3.Distance(worldPos, player.transform.position);
                    if (distance <= range)
                    {
                        if (Physics2D.OverlapCircle(worldPos,0.3f, terrainLayer) == null)
                        {
                            audioManager.Play("VoidShoot");
                            GameObject instantiatedPrefab = ObjectPoolVoid.instance.GetPooledObject();
                            if (instantiatedPrefab == null)
                            {
                                return;
                            }
                            instantiatedPrefab.transform.position = worldPos;
                            instantiatedPrefab.SetActive(true);

                            instantiatedPrefab.transform.localScale = scale;
                            manaSystem.ReduceMana(manaCost);
                            StartCoroutine(DeactivateAfterDelay(instantiatedPrefab, destroyDelay));
                            nextFireTime = Time.time + cooldown;
                        }
                    }
                }
                else
                {
                audioManager.Play("NoMana");
                }
            }
        }
        
        voidCd.value = nextFireTime > Time.time ? 1 - (nextFireTime - Time.time) / cooldown : 1;
        // Actualiza la posici?n de la l?nea

    }
    IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
    {

        yield return new WaitForSeconds(delay);

        if (obj.activeSelf)
        {
            Debug.Log("YAAAAA");
            obj.SetActive(false);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(player.transform.position, range);
    //}
}