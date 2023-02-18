using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public float damage = 100f;
    private float damageStartTime;
    private List<Enemy> enemiesInside = new List<Enemy>();
    private List<GameObject> rocksInside = new List<GameObject>();
    WeaponLevelBlast weaponLevelBlast;
    public GameObject EnemyEffect;
    public GameObject Effect;
    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
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
        if (other.tag == "Rock")
        {
        GameObject rock = other.gameObject;
                rocksInside.Add(rock);
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
            GameObject Enemyeffect = Instantiate(EnemyEffect, enemy.transform.position, Quaternion.identity);
            Enemyeffect.transform.localScale = scale;
            ParticleSystem ps = Enemyeffect.GetComponent<ParticleSystem>();
            Renderer psRenderer = ps.GetComponent<Renderer>();
            psRenderer.sortingOrder = 11;
        }
        foreach (GameObject rock in rocksInside)
        {
            if (!rock)
                return;
            Destroy(rock);
            GameObject effect = Instantiate(Effect, rock.transform.position, Quaternion.identity);
            effect.transform.localScale = scale;
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            Renderer psRenderer = ps.GetComponent<Renderer>();
            psRenderer.sortingOrder = 11;
        }
        this.GetComponent<Collider2D>().enabled = false;
    }
}