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
    WeaponsMenu weaponsMenu;
    CurrentCd currentCd;
    PauseMenu pauseMenu;
    void Start()
    {
        player = GameObject.Find("Player").transform; // busca el objeto player
        nextFireTime = 0f;
        iceCd = GameObject.Find("iceCd").GetComponent<Slider>();
        weaponsMenu = FindObjectOfType<WeaponsMenu>();
        currentCd = GetComponentInParent<CurrentCd>();
        nextFireTime = currentCd.iceBallCd;
        pauseMenu = FindObjectOfType<PauseMenu>();
    }
    
    void Update()
    {

        if (weaponsMenu.isMenuActive == true || pauseMenu.GameIsPause == true)
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
                
                    Shoot.Play();
                    Vector3 mousePos = Input.mousePosition;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                    worldPos.z = player.position.z;
                    GameObject instantiatedPrefab = Instantiate(prefab, player.position, Quaternion.identity);
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
                    Vector3 direction = (worldPos - player.position).normalized;
                    rb.AddForce(direction * force, ForceMode2D.Impulse);

                    Destroy(instantiatedPrefab, destroyDelay);
                    nextFireTime = Time.time + cooldown;
                }
            }
        }
        iceCd.value = nextFireTime > Time.time ? 1 - (nextFireTime - Time.time) / cooldown : 1;


    }
}