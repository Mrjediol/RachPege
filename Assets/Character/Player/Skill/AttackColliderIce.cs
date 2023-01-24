using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderIce : MonoBehaviour
{
    public Collider2D Collider;
    public float IceDamage = 10;



    MoveMouseDirection moveMouseDirection;
    public bool piercing = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Deal damage to the enemy
            //Debug.Log("llego a 1");
            Enemy enemy = other.GetComponent<Enemy>();
            //FrozenEffect frozenEffect = other.GetComponent<FrozenEffect>();
            Debug.Log("1");
            if (enemy != null)
            {
                Debug.Log("2");
                enemy.Takehit(IceDamage);
                if (piercing == false)
                    Debug.Log("3");
                Destroy(gameObject);
            }
            //if (burnEffect != null)
            //{
            //    Debug.Log("4");
            //    StartCoroutine(burnEffect.ApplyBurnDamage());
            //}
        }
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


