using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniquilationAttack : MonoBehaviour
{

    InstantiateAniquilation instantiateAniquilation;
    void Start()
    {
        instantiateAniquilation = GetComponentInParent<InstantiateAniquilation>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (!other.CompareTag("Enemy"))
            return;
        Debug.Log("tag enemigo pasado");
        Enemy enemy = other.GetComponent<Enemy>();
        WeaponLevelAniquilation weaponLevelAniquilation = GetComponentInParent<WeaponLevelAniquilation>();
        if (enemy == null)
            return;
        Debug.Log("no es nulo");
        enemy.Takehit(instantiateAniquilation.damage);
        if (weaponLevelAniquilation.level < 5f)
        {

            weaponLevelAniquilation.GetXp(instantiateAniquilation.damage);

        }
        DPS dps = other.GetComponent<DPS>();
        if (!other.CompareTag("Enemy") && !other.CompareTag("CheckPoint") && !other.CompareTag("Player") && !other.CompareTag("DetectionZone") && !other.CompareTag("ManaStart") && !other.CompareTag("VoidAttack"))
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
        if (dps != null)
        {
            dps.TakeDamage(instantiateAniquilation.damage);
            Destroy(gameObject);
        }
    }

}
