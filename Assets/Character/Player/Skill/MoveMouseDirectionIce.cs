using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class MoveMouseDirectionIce : MonoBehaviour
{
    private Transform player; //objeto al que se movera el prefab
    private float nextFireTime;
    private Slider iceCd;
    public float force = 3f; // fuerza a la que se moverá el objeto
    public float destroyDelay = 1f; //tiempo para destruir el objeto en segundos
    public float IceDamage = 10f;
    public float fireDamage = 10f;
    public float manaCost = 10f;
    public float cooldown = 2f;
    public bool piercing = false;
    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
    public GameObject prefab;
    [SerializeField] private AudioSource Shoot;
    CurrentCd currentCd;
    public LayerMask terrainLayer;
    Death death;
    AudioManager audioManager;
    void Start()
    {
        player = GameObject.Find("Player").transform; // busca el objeto player
        nextFireTime = 0f;
        iceCd = GameObject.Find("iceCd").GetComponent<Slider>();
        currentCd = GetComponentInParent<CurrentCd>();
        nextFireTime = currentCd.iceBallCd;
        death = FindObjectOfType<Death>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    void Update()
    {

        if (Time.timeScale == 0 || death.isDead == true)
            return;
        currentCd.iceBallCd = nextFireTime;
        if (iceCd.value >= 1.0f)
        {
            iceCd.gameObject.SetActive(false);
        }
        else
        {
            iceCd.gameObject.SetActive(true);
        }

        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ManaSystem manaSystem = FindObjectOfType<ManaSystem>();
                if(manaSystem.currentMana > manaCost) 
                {
                    Vector3 mousePos = Input.mousePosition;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                    worldPos.z = player.position.z;
                    Vector3 direction = (worldPos - player.position).normalized;
                    Vector3 spawnPosition = player.position - (player.up * 0.0147f) + (direction / 10);
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    if (Physics2D.OverlapCircle(spawnPosition, 0.05f, terrainLayer) == null)
                    {
                        audioManager.Play("IceShoot");

                        GameObject instantiatedPrefab = Instantiate(prefab, spawnPosition, Quaternion.Euler(0, 0, angle));
                        Rigidbody2D rb = instantiatedPrefab.GetComponent<Rigidbody2D>();
                        instantiatedPrefab.transform.parent = transform;
                        instantiatedPrefab.transform.localScale = scale;
                        if (instantiatedPrefab.name == "FireBall(Clone)")
                        {
                            instantiatedPrefab.GetComponent<AttackCollider>().fireDamage = fireDamage;
                            instantiatedPrefab.GetComponent<AttackCollider>().piercing = piercing;
                        }
                        if (instantiatedPrefab.name == "IceBall(Clone)")
                        {
                            instantiatedPrefab.GetComponent<AttackColliderIce>().IceDamage = IceDamage;
                            instantiatedPrefab.GetComponent<AttackColliderIce>().piercing = piercing;
                        }
                        manaSystem.ReduceMana(manaCost);
                        //manaSystem.currentMana -= manaCost;
                        rb.AddForce(direction * force, ForceMode2D.Impulse);

                        Destroy(instantiatedPrefab, destroyDelay);
                        nextFireTime = Time.time + cooldown;
                    }
                }
                else
                {
                    audioManager.Play("NoMana");
                }
            }
        }
        iceCd.value = nextFireTime > Time.time ? 1 - (nextFireTime - Time.time) / cooldown : 1;


    }
}