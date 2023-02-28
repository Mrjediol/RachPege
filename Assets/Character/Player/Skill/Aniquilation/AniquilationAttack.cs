using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniquilationAttack : MonoBehaviour
{
    public GameObject Effect;
    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
    InstantiateAniquilation instantiateAniquilation;
    OnFire torch;
    void Start()
    {
        instantiateAniquilation = GetComponentInParent<InstantiateAniquilation>();
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Torch"))
        {
            GameObject effect = Instantiate(Effect, other.transform.position, Quaternion.identity);
            effect.transform.localScale = scale;
            effect.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            Renderer psRenderer = ps.GetComponent<Renderer>();
            psRenderer.sortingOrder = 11;
            torch = other.GetComponent<OnFire>();
            torch.Limit();
        }
        if (!other.CompareTag("Enemy"))
            return;
        Enemy enemy = other.GetComponent<Enemy>();
        WeaponLevelAniquilation weaponLevelAniquilation = GetComponentInParent<WeaponLevelAniquilation>();
        if (enemy == null)
            return;
        enemy.Takehit(instantiateAniquilation.damage);
        if (weaponLevelAniquilation.level < 5f)
        {

            weaponLevelAniquilation.GetXp(instantiateAniquilation.damage);

        }
        DPS dps = other.GetComponent<DPS>();
        if (other.CompareTag("Fence") || other.CompareTag("Terrain") || other.CompareTag("FireFence") || other.CompareTag("IceFence") || other.CompareTag("Rock") || other.CompareTag("Torch"))
        {
            Destroy(gameObject);
        }
        if (dps != null)
        {
            dps.TakeDamage(instantiateAniquilation.damage);
            Destroy(gameObject);
        }
    }

}
