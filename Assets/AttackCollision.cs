using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    public float enemyDamageAttack = 3;
    public Collider2D attackCollider;
    public float knockBackForce = 1000f;
    public bool imBullet;
    public GameObject effectBullet;
    public Transform father;
    private void Start()
    {
        Enemy enemy = GetComponentInParent<Enemy>();
        enemyDamageAttack = enemy.enemyDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

            PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();
            Rigidbody2D rb = collision.gameObject.GetComponentInParent<Rigidbody2D>();
            if (player != null)
            {

                Vector2 direction;
                if (father != null)
                {
                     direction = (rb.transform.position - father.position).normalized;
                }
                else 
                {
                     direction = (rb.transform.position - transform.position).normalized;
                }
                Vector2 knockBack = direction * knockBackForce;

                if (imBullet)
                {
                    Destroy(this.gameObject);
                    GameObject effect = Instantiate(effectBullet, collision.transform.position, Quaternion.identity);
                    ParticleSystem ps = effect.GetComponent<ParticleSystem>();
                    Renderer psRenderer = ps.GetComponent<Renderer>();
                    psRenderer.sortingOrder = 11;
                    psRenderer.sortingLayerName = "arboles";
                    enemyDamageAttack *=  0.75f;
                }
                //rb.AddForce(knockBack * Time.fixedDeltaTime * direction);
                player.TakeDamage(enemyDamageAttack, knockBack);
            }
        }
        if (collision.gameObject.CompareTag("Fence") || collision.CompareTag("Terrain") || collision.CompareTag("FireFence") || collision.CompareTag("IceFence") || collision.CompareTag("Rock") || collision.CompareTag("Torch"))
        {

            Destroy(gameObject);

        }
    }

}
