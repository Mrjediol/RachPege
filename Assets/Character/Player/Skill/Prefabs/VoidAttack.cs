using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidAttack : MonoBehaviour
{
    public Collider2D voidCollider;
    public float damage = 30;
    Enemy enemy;
    public float rotationSpeed = 100f;
    WeaponLevelVoid weaponLevelVoid;
    AudioManager audioManager;
    InstantiateOnClickVoid instantiateOnClickVoid;
    private void Start()
    {
        weaponLevelVoid = FindObjectOfType<WeaponLevelVoid>();
        audioManager = FindObjectOfType<AudioManager>();
        instantiateOnClickVoid = FindObjectOfType<InstantiateOnClickVoid>();
    }
    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
        rotationSpeed = weaponLevelVoid.rotationSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("llego a 4");
        if (other.tag == "Enemy")
        {

            // Deal damage to the enemy
            Debug.Log("llego a 1");
            enemy = other.GetComponent<Enemy>();
            WeaponLevelVoid weaponLevelVoid = FindObjectOfType<WeaponLevelVoid>();
            if (enemy != null)
            {
                if(weaponLevelVoid != null) 
                {
                    if (weaponLevelVoid.level < 5f)
                    {

                     weaponLevelVoid.GetXp(damage);
                    
                    }
                }
                else
                {
                    gameObject.SetActive(false);
                }
                Debug.Log("llego a 2");
                audioManager.Play("VoidHit");
                if(gameObject.activeInHierarchy)
                StartCoroutine(enemy.VoidAttack(damage));
                
            }


            //if (burnEffect != null)
            //{
            //    Debug.Log("4");
            //    StartCoroutine(burnEffect.ApplyBurnDamage());
            //}
        }
        DPS dps = other.GetComponent<DPS>();
        if (dps != null)
        {
            dps.TakeDamage(damage);
        }
    }
    private void OnDisable()
    {
        if (instantiateOnClickVoid)
            instantiateOnClickVoid.StopAllCoroutines();
    }
    //private void OnDestroy()
    //{
    //    if (enemy != null)
    //    {
    //        enemy.StopVoidAttack();
    //    }
    //}

}
