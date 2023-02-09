using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public float damage = 100f;
    private float damageStartTime;
    private List<Enemy> enemiesInside = new List<Enemy>();
    WeaponLevelBlast weaponLevelBlast;
    private void Start()
    {
        damageStartTime = Time.time + 6.45f;
        weaponLevelBlast = GetComponentInParent<WeaponLevelBlast>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemiesInside.Add(enemy);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemiesInside.Remove(enemy);
            }
        }
    }

    private void Update()
    {
        if (Time.time < damageStartTime)
        {
            return;
        }
        foreach (Enemy enemy in enemiesInside)
        {
            enemy.Takehit(damage);
            if (weaponLevelBlast.level < 5f)
            {
                weaponLevelBlast.GetXp(damage);
            }
            
        }
        this.GetComponent<Collider2D>().enabled = false;
    }
}