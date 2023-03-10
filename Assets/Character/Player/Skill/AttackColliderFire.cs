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
    public GameObject smokeEffect;
    public Transform smokePosition;
    AudioManager audioManager;
    WeaponLevelFire weaponLevelFire;
    MoveMouseDirectionFire moveMouseDirectionFire;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
     
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        moveMouseDirectionFire = FindObjectOfType<MoveMouseDirectionFire>();
        if (other.tag == "Enemy")
        {
            
            // Deal damage to the enemy
            Debug.Log("llego a 1");
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy.imtheBoss == true)
            {
                gameObject.SetActive(false);
                return;
            }

            //BurnEffect burnEffect = other.GetComponent<BurnEffect>();
            weaponLevelFire = FindObjectOfType<WeaponLevelFire>();

            if (enemy != null)
            {
                BurnEffect burnEffect = other.gameObject.GetComponent<BurnEffect>();
                if(burnEffect == null)
                {
                    burnEffect = other.gameObject.AddComponent<BurnEffect>();
                }
                
                    smokePosition = other.transform;

                 if (weaponLevelFire.level < 5f)
                  {

                    weaponLevelFire.GetXp(fireDamage);
                    //Savexpfire()
                    }
                
                audioManager.Play("FireHit");
                Debug.Log("llego a 2");
                GameObject effect = Instantiate(smokeEffect, smokePosition.position, Quaternion.identity);
                Destroy(effect, 1f);
                if(enemy.imTrunk)
                {
                    enemy.Takehit(fireDamage * 1.2f);
                }
                else
                {
                enemy.Takehit(fireDamage);

                }
                if (piercing == false)
                {
                    Debug.Log("llego a 3");
                    gameObject.SetActive(false);
                }
            }


            //if (burnEffect != null)
            //{
            //    Debug.Log("4");
            //    StartCoroutine(burnEffect.ApplyBurnDamage());
            //}
        }
        if (other.CompareTag("Fence") || other.CompareTag("Terrain") || other.CompareTag("FireFence") || other.CompareTag("IceFence") || other.CompareTag("Rock") || other.CompareTag("Torch"))
        {
            Debug.Log(other.tag);
            gameObject.SetActive(false);

        }
        if (other.CompareTag("FireFence"))
        {
            Destroy(other.gameObject ,1f);
            audioManager.Play("FireLimit");
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

            // Iterar a trav?s de los transformadores hijos de la ParticleSystem
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
            gameObject.SetActive(false);
            
        }
    }
    private void OnDisable()
    {
        if(moveMouseDirectionFire)
        moveMouseDirectionFire.StopAllCoroutines();
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



//            Debug.Log("Hago Da?o");

//            enemy.Takehit(damage);
//        }
//    }
//}


