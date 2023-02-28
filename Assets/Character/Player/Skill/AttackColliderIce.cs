using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderIce : MonoBehaviour
{
    public Collider2D Collider;
    public float IceDamage = 10;


    public GameObject hitEffect;

    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);

    public bool piercing = false;

    public GameObject smokeEffect;
    public Transform smokePosition;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Deal damage to the enemy
            //Debug.Log("llego a 1");
            Enemy enemy = other.GetComponent<Enemy>();
            WeaponLevelIce weaponlevelIce = GetComponentInParent<WeaponLevelIce>();
            //frozeneffect frozeneffect = other.getcomponent<frozeneffect>();
            //Debug.Log("1");
            if (enemy != null)
            {
                smokePosition = other.transform;
                if (weaponlevelIce.level < 5f)
                {
                    
                    weaponlevelIce.GetXp(IceDamage);
                   
                }
                //Debug.Log("2");
                audioManager.Play("IceHit");
                GameObject effect = Instantiate(smokeEffect, smokePosition.position, Quaternion.identity);
                Destroy(effect, 1f);
                enemy.Takehit(IceDamage);
                if (piercing == false)
                {
                    //Debug.Log("3");
                    Destroy(gameObject);
                }
            }
            //if (burnEffect != null)
            //{
            //    Debug.Log("4");
            //    StartCoroutine(burnEffect.ApplyBurnDamage());
            //}
        }
        //if (!other.CompareTag("Enemy") && !other.CompareTag("Ignore") && !other.CompareTag("CheckPoint") && !other.CompareTag("Player") && !other.CompareTag("DetectionZone") && !other.CompareTag("ManaStart") && !other.CompareTag("VoidAttack") && !other.CompareTag("Water") && !other.CompareTag("Torch"))
       if(other.CompareTag("Fence") || other.CompareTag("Terrain") || other.CompareTag("FireFence") || other.CompareTag("IceFence") || other.CompareTag("Rock") || other.CompareTag("Torch"))
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
        if (other.CompareTag("IceFence"))
        {
            audioManager.Play("IceLimit");
            Destroy(other.gameObject, 0.8f);
            Transform fireFence = other.GetComponent<Transform>();

            GameObject effect = Instantiate(hitEffect, fireFence.transform.position, Quaternion.identity);
            effect.transform.localScale = scale;
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            Renderer psRenderer = ps.GetComponent<Renderer>();
            psRenderer.sortingOrder = 11;
        }
        DPS dps = other.GetComponent<DPS>();
        if (dps != null)
        {
            dps.TakeDamage(IceDamage);
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


