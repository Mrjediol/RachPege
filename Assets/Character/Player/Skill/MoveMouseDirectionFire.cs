using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class MoveMouseDirectionFire : MonoBehaviour
{
    public float force = 3f; // fuerza a la que se moverá el objeto
    public float destroyDelay = 1f; //tiempo para destruir el objeto en segundos
    private Transform player; //objeto al que se movera el prefab
    public GameObject prefab;
    [SerializeField] private AudioSource Shoot;
    public float fireDamage = 5f;
    public float IceDamage = 5f;
    
    public bool piercing = false;
    public Vector3 scale = new Vector3(1, 1, 1);
    public float cooldown = 0.5f;
    private float nextFireTime;
    public Slider fireCd;
    void Start()
    {
        player = GameObject.Find("Player").transform; // busca el objeto player
        nextFireTime = 0f;
        fireCd = GameObject.Find("fireCd").GetComponent<Slider>();
    }

    void Update()
    {
        if (fireCd.value >= 1.0f)
        {
            fireCd.gameObject.SetActive(false);
        }
        else
        {
            fireCd.gameObject.SetActive(true);
        }
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
                if (instantiatedPrefab.name == "FireBall(Clone)") 
                {
                    instantiatedPrefab.GetComponent<AttackColliderFire>().fireDamage = fireDamage;
                    instantiatedPrefab.GetComponent<AttackColliderFire>().piercing = piercing;
                }
                if (instantiatedPrefab.name == "IceBall(Clone)")
                {
                    instantiatedPrefab.GetComponent<AttackColliderIce>().IceDamage = IceDamage;
                    instantiatedPrefab.GetComponent<AttackColliderIce>().piercing = piercing;
                }

                Vector3 direction = (worldPos - player.position).normalized;
                rb.AddForce(direction * force, ForceMode2D.Impulse);
                Destroy(instantiatedPrefab, destroyDelay);
                nextFireTime = Time.time + cooldown;
            }
        }
        fireCd.value = nextFireTime > Time.time ? 1 - (nextFireTime - Time.time) / cooldown : 1;
    }
}