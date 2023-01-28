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
    //Animator animator;
    WeaponManager weaponManager;
    SaveState saveState;
    private void Start()
    {

        weaponManager = FindObjectOfType<WeaponManager>();
        saveState = FindObjectOfType<SaveState>();
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
                }
            }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Iceball")
        {
            if (Random.Range(0f, 100f) <= probability)
            {
                StartCoroutine(ApplyFrozenDamage());
            }
        }
    }

    public IEnumerator ApplyFrozenDamage()
    {
        //Image burnImage = GetComponentInChildren<Image>();
        FrozenImage.SetActive(true);


        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {


            Enemy enemy = GetComponent<Enemy>();
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

