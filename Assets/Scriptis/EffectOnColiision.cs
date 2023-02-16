using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnColiision : MonoBehaviour
{

    public GameObject hitEffect;

    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Transform enemy = collision.GetComponent<Transform>();
            
            GameObject effect = Instantiate(hitEffect, enemy.transform.position, Quaternion.identity);
            effect.transform.localScale = scale;
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            Renderer psRenderer = ps.GetComponent<Renderer>();
            psRenderer.sortingOrder = 11;
            
        }
    }
}