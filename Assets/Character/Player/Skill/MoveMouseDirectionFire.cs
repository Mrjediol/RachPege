using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class MoveMouseDirectionFire : MonoBehaviour
{
    private float nextFireTime;
    private Transform player; //objeto al que se movera el prefab
    public float force = 3f; // fuerza a la que se mover? el objeto
    public float destroyDelay = 1f; //tiempo para destruir el objeto en segundos
    public float fireDamage = 5f;
    public float IceDamage = 5f;
    public float manaCost = 10f;
    public float cooldown = 0.5f;
    public bool piercing = false;
    public int levelRequirement;
    public Vector3 scale = new Vector3(1, 1, 1);
    [SerializeField] private AudioSource Shoot;
    public GameObject prefab;
    public Slider fireCd;
    CurrentCd currentCd;
    public LayerMask terrainLayer;
    Death death;
    AudioManager audioManager;
    void Start()
    {
        player = GameObject.Find("Player").transform; // busca el objeto player
        nextFireTime = 0f;
        fireCd = GameObject.Find("fireCd").GetComponent<Slider>();
        currentCd = GetComponentInParent<CurrentCd>();
        nextFireTime = currentCd.fireBallCd;
        death = FindObjectOfType<Death>();
        audioManager = FindObjectOfType<AudioManager>();

    }

    void Update()
    {
        if (Time.timeScale == 0 || death.isDead == true)
            return;
        currentCd.fireBallCd = nextFireTime;
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
                ManaSystem manaSystem = FindObjectOfType<ManaSystem>();
                if (manaSystem.currentMana > manaCost)
                {
                    Vector3 mousePos = Input.mousePosition;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                    worldPos.z = player.position.z;
                    Vector3 direction = (worldPos - player.position).normalized;
                    Vector3 spawnPosition = player.position - (player.up * 0.0147f) + (direction / 10);
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    //angle -= 90;
                    if (Physics2D.OverlapCircle(spawnPosition, 0.05f, terrainLayer) == null)
                    {
                        audioManager.Play("FireShoot");

                        //GameObject instantiatedPrefab = Instantiate(prefab, spawnPosition, Quaternion.Euler(0, 0, angle));
                        GameObject instantiatedPrefab = ObjectPoolFire.instance.GetPooledObject();
                        if(instantiatedPrefab == null)
                        {
                            return;
                        }
                        instantiatedPrefab.transform.position = spawnPosition;
                        instantiatedPrefab.transform.rotation = Quaternion.Euler(0, 0, angle);
                        instantiatedPrefab.SetActive(true);
                        Rigidbody2D rb = instantiatedPrefab.GetComponent<Rigidbody2D>();
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
                        manaSystem.ReduceMana(manaCost);
                        rb.AddForce(direction * force, ForceMode2D.Impulse);
                        StartCoroutine(DeactivateAfterDelay(instantiatedPrefab, destroyDelay));
                        nextFireTime = Time.time + cooldown;
                    }
                }
                else
                {
                    audioManager.Play("NoMana");
                }
            }
        }
        fireCd.value = nextFireTime > Time.time ? 1 - (nextFireTime - Time.time) / cooldown : 1;
    }

    IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
    {
        if (obj.activeInHierarchy == false)
        {
            yield break;
        }
        yield return new WaitForSeconds(delay);
        
        if (obj.activeSelf)
        {
            Debug.Log("YAAAAA");
            obj.SetActive(false);
        }
    }
}