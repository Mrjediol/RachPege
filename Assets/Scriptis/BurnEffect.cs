using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class BurnEffect : MonoBehaviour
{
    public float damageOverTime = 1f;
    public float timeBetweenDamage = 1f;
    public float duration = 5f;
    public float probability = 50f;
    //public Image burnImage;
    public GameObject burnImage;
    public float damage;
    WeaponManager weaponManager;
    SaveState saveState;
    FrozenEffect frozenEffect;
    MoveMouseDirectionFire moveMouseDirectionFire;
    public GameObject smokeEffect;
    public Vector3 scale = new(0.15f, 0.15f, 0.15f);
    Enemy enemy;

    private void Start()
    {
        frozenEffect = GetComponent<FrozenEffect>();
        moveMouseDirectionFire = FindObjectOfType<MoveMouseDirectionFire>();
        weaponManager = FindObjectOfType<WeaponManager>();
        saveState = FindObjectOfType<SaveState>();
        enemy = GetComponent<Enemy>();
        
    }
    private void Update()
    {

        if (weaponManager.currentWeapon != null)
        {
            if (weaponManager.currentWeapon.name == "FireBall(Clone)")
            {
                probability = saveState.burnprobability;
                damageOverTime = saveState.burndamageOverTime;
                duration = saveState.burnduration;
                timeBetweenDamage = saveState.burntimeBetweenDamage;
                damage = saveState.fireDamage;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fireball")
        {


            if (Random.Range(0f, 100f) <= probability)
            {
                if (frozenEffect.FrozenImage.activeInHierarchy)
                {
                    IceAndFireExplosion();
                    return;
                }
                StartCoroutine(ApplyBurnDamage());
            }
        }
    }
    public void IceAndFireExplosion()
    {
        enemy.Takehit(damage * 2);
        GameObject effect = Instantiate(smokeEffect, transform.position, Quaternion.identity);
        effect.transform.localScale = scale;

        ParticleSystem ps = effect.GetComponent<ParticleSystem>();
        Renderer psRenderer = ps.GetComponent<Renderer>();
        psRenderer.sortingOrder = 11;
        psRenderer.sortingLayerName = "arboles";
    }
    public IEnumerator ApplyBurnDamage()
    {
        //Image burnImage = GetComponentInChildren<Image>();
        burnImage.SetActive(true);
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            
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
        burnImage.SetActive(false);
    }

    public void ApplyDamage(Enemy enemy, float damage)
    {
        Debug.Log("5");

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
