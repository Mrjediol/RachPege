using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class FrozenEffect : MonoBehaviour
{


    public float damageOverTime = 1f;
    public float timeBetweenDamage = 2f;
    public float duration = 6f;
    public float probability = 50f;
    //public Image burnImage;
    public GameObject FrozenImage;
    public float freezeDuration = 6f;
    private float freezeTimer = 0f;
    public bool isFrozen = false;
    public float damage;
    //Animator animator;
    WeaponManager weaponManager;
    SaveState saveState;
    BurnEffect burnEffect;
    Enemy enemy;
    Animator animator;
    RunState run;
    public GameObject smokeEffect;
    public Vector3 scale = new(0.2f, 0.2f, 0.2f);
    Trunk trunk;
    private void Start()
    {
        FrozenImage = transform.Find("FrozenImage").gameObject;
        smokeEffect = Resources.Load<GameObject>("SmokeVariant");
        animator = GetComponent<Animator>();
        burnEffect = GetComponent<BurnEffect>();
        weaponManager = FindObjectOfType<WeaponManager>();
        saveState = FindObjectOfType<SaveState>();
        enemy = GetComponent<Enemy>();
        if (enemy.imTrunk)
        {
        trunk = GetComponent<Trunk>();
        }
        if (enemy.imFur)
        {
        run = animator.GetBehaviour<RunState>();
        }
    }
    private void Update()
    {
        if (weaponManager.currentWeapon != null)
            {
                if (weaponManager.currentWeapon.name == "IceBall(Clone)")
                {
                    probability = saveState.fronzedprobability;
                    damageOverTime = saveState.frozendamageOverTime;
                    duration = saveState.frozenduration;
                    timeBetweenDamage = saveState.frozentimeBetweenDamage;
                    freezeDuration = saveState.frozenFreezeduration;
                    damage = saveState.iceDamage;
                }
            }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Iceball")
        {
            if (Random.Range(0f, 100f) <= probability)
            {
                if(burnEffect != null)
                {

                    if (burnEffect.burnImage.activeInHierarchy)
                     {
                    FireAndIceExplosion();
                     return;
                     }
                }

               StartCoroutine(ApplyFrozenDamage());
               
            }
        }
    }
    public void FireAndIceExplosion()
    {
        enemy.Takehit(damage * 2);
        GameObject effect = Instantiate(smokeEffect, transform.position, Quaternion.identity);
        effect.transform.localScale = scale;

        ParticleSystem ps = effect.GetComponent<ParticleSystem>();
        Renderer psRenderer = ps.GetComponent<Renderer>();
        psRenderer.sortingOrder = 11;
        psRenderer.sortingLayerName = "arboles";
    }
    public IEnumerator ApplyFrozenDamage()
    {
        //Image burnImage = GetComponentInChildren<Image>();
        FrozenImage.SetActive(true);
        animator.speed = 0.5f;
        if (enemy.imFur)
        {
        run.speed = enemy.slowedmoveSpeed;
        }
        if (enemy.imTrunk)
        {
            trunk.speed = trunk.slowedSpeed;
        }
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {

            if (enemy != null)
            {
                ApplyDamage(enemy, damageOverTime);

                timeElapsed += timeBetweenDamage;
                isFrozen = true;
                freezeTimer = freezeDuration;


                yield return new WaitForSeconds(timeBetweenDamage);
            }
            else
            {
                Debug.LogError("No se ha encontrado el componente 'Enemy' en el objeto " + enemy.name);
                yield break;
            }
        }
        FrozenImage.SetActive(false);
        animator.speed = 1f;
        if (enemy.imFur)
        {
        run.speed = enemy.initialSpeed;
        }
        if (enemy.imTrunk)
        {
            trunk.speed = trunk.initialSpeed;
        }

    }

    public void ApplyDamage(Enemy enemy, float damage)
    {
        enemy.Takehit(damage);
    }
    void FixedUpdate()
    {
        if (isFrozen)
        {
            //animator.SetTrigger("isFrozen");
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0f)
            {
                isFrozen = false;
            }
        }
    }
}

