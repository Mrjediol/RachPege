using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class MoveMouseDirectionRay : MonoBehaviour
{
    private float nextFireTime;
    private Transform player; //objeto al que se movera el prefab
    public float force = 1f; // fuerza a la que se mover� el objeto
/*    public float destroyDelay = 0.2f;*/ //tiempo para destruir el objeto en segundos
    public float fireDamage = 5f;
    public float IceDamage = 5f;
    public float manaCost = 50f;
    public float cooldown = 0.5f;
    public bool piercing = false;
    public Vector3 scale = new Vector3(1, 1, 1);
    [SerializeField] private AudioSource Shoot;
    public GameObject prefab;
    public Slider rayCd;
    public GameObject weaponsMenu;
    void Start()
    {
        rayCd = GameObject.Find("rayCd").GetComponent<Slider>();
        player = GameObject.Find("Player").transform; // busca el objeto player
        nextFireTime = 0f;
 
    }

    void Update()
    {
        if (rayCd.value >= 1.0f)
        {
            rayCd.gameObject.SetActive(false);
        }
        else
        {
            rayCd.gameObject.SetActive(true);
        }
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            
            {
            ManaSystem manaSystem = FindObjectOfType<ManaSystem>();
            if (manaSystem.currentMana > manaCost)
            {
                Shoot.Play();
                    Vector3 mousePos = Input.mousePosition;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                    worldPos.z = player.position.z;
                    GameObject instantiatedPrefab = Instantiate(prefab, player.position, Quaternion.identity);
                    Rigidbody2D rb = instantiatedPrefab.GetComponent<Rigidbody2D>();
                    instantiatedPrefab.transform.parent = transform;
                    //instantiatedPrefab.transform.localScale = scale;
                    manaSystem.ReduceMana(manaCost);
                    Vector3 direction = (worldPos - player.position).normalized;
                    rb.AddForce(direction * force, ForceMode2D.Impulse);
                    //Destroy(instantiatedPrefab, destroyDelay);
                    nextFireTime = Time.time + cooldown;
                }
            }
        }
        rayCd.value = nextFireTime > Time.time ? 1 - (nextFireTime - Time.time) / cooldown : 1;
    }
    public void Teleport(Vector3 destination)
    {
        player.transform.position = destination;
    }
}


//if (instantiatedPrefab.name == "FireBall(Clone)")
//{
//    instantiatedPrefab.GetComponent<AttackColliderFire>().fireDamage = fireDamage;
//    instantiatedPrefab.GetComponent<AttackColliderFire>().piercing = piercing;
//}
