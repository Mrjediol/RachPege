using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderFire : MonoBehaviour
{
    public Collider2D Collider;
    public float fireDamage = 10;

    public GameObject hitEffect;

    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
    //MoveMouseDirection moveMouseDirection;
    public bool piercing = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Enemy")
        {
            
            // Deal damage to the enemy
            //Debug.Log("llego a 1");
            Enemy enemy = other.GetComponent<Enemy>();
            
            //BurnEffect burnEffect = other.GetComponent<BurnEffect>();
            Debug.Log("1");
            WeaponLevelFire weaponLevelFire = GetComponentInParent<WeaponLevelFire>();
            if (enemy != null)
            {
                Debug.Log("2");
                if (weaponLevelFire.level < 5f)
                {

                    weaponLevelFire.GetXp(fireDamage);
                    //Savexpfire()
                }

                enemy.Takehit(fireDamage);
                if (piercing == false)
                {
                    Debug.Log("3");
                    Destroy(gameObject);
                }
            }

            
            //if (burnEffect != null)
            //{
            //    Debug.Log("4");
            //    StartCoroutine(burnEffect.ApplyBurnDamage());
            //}
        }
        if (!other.CompareTag("Enemy") && !other.CompareTag("Ignore") && !other.CompareTag("CheckPoint") && !other.CompareTag("Player") && !other.CompareTag("DetectionZone") && !other.CompareTag("ManaStart") && !other.CompareTag("VoidAttack") && !other.CompareTag("Water") && !other.CompareTag("Torch"))
        {
            Debug.Log(other.tag);
            Destroy(gameObject);
        }
        if (other.CompareTag("Fence"))
        {
            Destroy(other.gameObject ,1f);
            Transform Fence = other.GetComponent<Transform>();
            Vector3 fencePos = Fence.transform.position;
            fencePos.y -= 0.05f;
            GameObject effect = Instantiate(hitEffect, fencePos, Quaternion.identity);
            effect.transform.localScale = scale;
            //ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            //Renderer psRenderer = ps.GetComponent<Renderer>();
            //psRenderer.sortingOrder = 11;
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            Renderer psRenderer = ps.GetComponent<Renderer>();
            psRenderer.sortingOrder = 11;

            // Iterar a través de los transformadores hijos de la ParticleSystem
            foreach (Transform child in ps.transform)
            {
                // Obtener el componente Renderer de cada hijo
                Renderer childRenderer = child.GetComponent<Renderer>();

                // Si el hijo tiene un componente Renderer, ajustar su sorting order
                if (childRenderer != null)
                {
                    childRenderer.sortingOrder = 11;
                }
            }
        }
        DPS dps = other.GetComponent<DPS>();
        if (dps != null)
        {
            dps.TakeDamage(fireDamage);
            Destroy(gameObject);
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


