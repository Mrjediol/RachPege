using System.Collections;
using UnityEngine;


public class BurnEffect : MonoBehaviour
{
    public float damageOverTime = 1f;
    public float timeBetweenDamage = 1f;
    public float duration = 5f;
    public float probability = 50f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fireball")
        {
            if (Random.Range(0f, 100f) <= probability)
            {
                StartCoroutine(ApplyBurnDamage());
            }
        }
    }

    public IEnumerator ApplyBurnDamage()
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            Enemy enemy = GetComponent<Enemy>();
            if (enemy != null)
            {
                ApplyDamage(enemy, damageOverTime);
                timeElapsed += timeBetweenDamage;
                yield return new WaitForSeconds(timeBetweenDamage);
            }
            else
            {
                Debug.LogError("No se ha encontrado el componente 'Enemy' en el objeto " + enemy.name);
                yield break;
            }
        }
    }

    public void ApplyDamage(Enemy enemy, float damage)
    {
        enemy.Takehit(damage);
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class BurnEffect : MonoBehaviour
//{
//    //public float fireDamage = 10;
//    public float damageOverTime = 1f;
//    public float timeBetweenDamage = 1f;
//    public float duration = 5f;
//    public float probability = 50f;

//    public Enemy enemy;
//    private void Start()
//    {

//    }
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.tag == "Fireball")
//        {
//            // Deal damage to the enemy
//            if (Random.Range(0f, 100f) <= probability)
//            {
//                StartCoroutine(ApplyDamageOverTime());
//            }
//        }
//    }

//    IEnumerator ApplyDamageOverTime()
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
