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
    }
}