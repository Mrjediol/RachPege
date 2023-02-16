using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    public float enemyDamageAttack = 3;
    Vector2 enemyAttackOffset;
    public Collider2D attackCollider;

    public float knockBack = 1000f;

    public Collision2D lastCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lastCollision = collision;
            // Resto del código de la función
        }
    }

    private void EnemyAttack()
    {
        if (lastCollision != null && lastCollision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = lastCollision.gameObject.GetComponent<PlayerHealth>();
            Rigidbody2D rb = lastCollision.gameObject.GetComponent<Rigidbody2D>();

            if (player != null)
            {
                Vector2 direction = (rb.transform.position - transform.position).normalized;
                rb.AddForce(knockBack * Time.fixedDeltaTime * direction);
                player.TakeDamage(enemyDamageAttack);
            }
        }
    }
}
