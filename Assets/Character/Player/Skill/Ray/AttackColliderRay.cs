using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderRay : MonoBehaviour
{
    public Collider2D Collider;
    public float fireDamage = 10;
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
                enemy.Takehit(fireDamage * enemyCount);
                ManaSystem mana = FindObjectOfType<ManaSystem>();
                if (mana.maxMana > mana.currentMana)
                {
                    float amountToAdd = Mathf.Min(manaRecieve * enemyCount, mana.maxMana - mana.currentMana);
                    mana.currentMana += amountToAdd;
                }
                if (weaponLevelRay.level < 5f)
                {
                    weaponLevelRay.GetXp((fireDamage * enemyCount)/2f);
                    //Savexpfire()
                }
            }
        }
        if (!other.CompareTag("Enemy") && !other.CompareTag("CheckPoint") && !other.CompareTag("Player") && !other.CompareTag("DetectionZone") && !other.CompareTag("ManaStart") && !other.CompareTag("VoidAttack"))
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
        DPS dps = other.GetComponent<DPS>();
        if (dps != null)
        {
            dps.TakeDamage(fireDamage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        finalPosition = transform.position;
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


