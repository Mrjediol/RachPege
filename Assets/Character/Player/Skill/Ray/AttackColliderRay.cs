using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderRay : MonoBehaviour
{
    public Collider2D Collider;
    public float rayDamage = 10;
    public Vector3 finalPosition;
    public float timeToLive = 2f;
    public float originalTimeToLive;
    //MoveMouseDirection moveMouseDirection;
    public bool piercing = false;
    MoveMouseDirectionRay moveMouseDirectionRay;
    private int enemyCount = 0;
    public float manaRecieve = 5f;
    private void Start()
    {
        moveMouseDirectionRay = GetComponentInParent<MoveMouseDirectionRay>();
        originalTimeToLive = timeToLive;

    }
    private void Update()
    {
        rayDamage = moveMouseDirectionRay.damage;
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Enemy")
        {
            timeToLive = originalTimeToLive;
            Enemy enemy = other.GetComponent<Enemy>(); 
            Debug.Log("1");
            WeaponLevelRay weaponLevelRay = GetComponentInParent<WeaponLevelRay>();
            if (enemy != null)
            {
                //Debug.Log("2");
               

                enemyCount++;
                FindObjectOfType<AudioManager>().Play("RayHit");
                enemy.Takehit(rayDamage * enemyCount);
                ManaSystem mana = FindObjectOfType<ManaSystem>();
                if (mana.maxMana > mana.currentMana)
                {
                    float amountToAdd = Mathf.Min(manaRecieve * enemyCount, mana.maxMana - mana.currentMana);
                    mana.currentMana += amountToAdd;
                }
                if (weaponLevelRay.level < 5f)
                {
                    weaponLevelRay.GetXp((rayDamage * enemyCount)/2f);
                    //Savexpfire()
                }
            }
        }
        if (!other.CompareTag("Enemy") && !other.CompareTag("Ignore") && !other.CompareTag("CheckPoint") && !other.CompareTag("Player") && !other.CompareTag("DetectionZone") && !other.CompareTag("ManaStart") && !other.CompareTag("VoidAttack") && !other.CompareTag("Water") && !other.CompareTag("Torch"))
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
        DPS dps = other.GetComponent<DPS>();
        if (dps != null)
        {
            dps.TakeDamage(rayDamage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        finalPosition = transform.position;
        Collider2D[] colliders = Physics2D.OverlapPointAll(finalPosition);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Water") || collider.CompareTag("Torch"))
            {
                return; // Si la posición final está en el agua, no envíes el mensaje "Teleport"
            }
        }
        SendMessageUpwards("Teleport", finalPosition);
    }
}
//    IEnumerator ApplyDamageOverTime(Enemy enemy)
//    {
//        float timeElapsed = 0f;
//        while (timeElapsed < duration)
//        {
//            enemy.Takehit(damageOverTime);
//            timeElapsed += timeBetweenDamage;
//            yield return new WaitForSeconds(timeBetweenDamage);
//        }
//    }
//}
//public void IncreaseDamage(int level)
//{
//    damage += level;
//    damage = Mathf.Round(damage);
//}

//private void OnCollisionEnter2D(Collision2D collision)
//{
//    if (collision.collider.gameObject.tag == "Enemy")
//    {
//        // Deal damage to the enemy
//        Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();

//        if (enemy != null)
//        {



//            Debug.Log("Hago Daño");

//            enemy.Takehit(damage);
//        }
//    }
//}


