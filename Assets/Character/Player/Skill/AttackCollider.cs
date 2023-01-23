using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Collider2D Collider;
    public float fireDamage = 10;
    public float damageOverTime = 1f;
    public float timeBetweenDamage = 1f;
    public float duration = 5f;
    public float probability = 50f;
    private float timeElapsed = 0f;
    MoveMouseDirection moveMouseDirection;
    public bool piercing = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Deal damage to the enemy
            //Debug.Log("llego a 1");
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                //Debug.Log("Hago Daño");
                enemy.Takehit(fireDamage);
                if (piercing == false)
                    Destroy(gameObject);
                if (Random.Range(0f, 100f) <= probability)
                {
                    StartCoroutine(ApplyDamageOverTime(enemy));
                }
            }
        }
    }

    IEnumerator ApplyDamageOverTime(Enemy enemy)
    {
        while (timeElapsed < duration)
        {
            enemy.Takehit(damageOverTime);
            timeElapsed += timeBetweenDamage;
            yield return new WaitForSeconds(timeBetweenDamage);
        }
    }
}
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


