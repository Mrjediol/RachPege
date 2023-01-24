using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class FrozenEffect : MonoBehaviour
{


    public float damageOverTime = 1f;
    public float timeBetweenDamage = 2f;
    public float duration = 5f;
    public float probability = 50f;
    //public Image burnImage;
    public GameObject FrozenImage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Iceball")
        {
            if (Random.Range(0f, 100f) <= probability)
            {
                StartCoroutine(ApplyBurnDamage());
            }
        }
    }

    public IEnumerator ApplyBurnDamage()
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
}

