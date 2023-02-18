using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    public float enemyDamageAttack = 3;
    public Collider2D attackCollider;
    public float knockBack = 1000f;

    private void Start()
    {
        Enemy enemy = GetComponentInParent<Enemy>();
        enemyDamageAttack = enemy.enemyDamage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (player != null)
            {
                Vector2 direction = (rb.transform.position - transform.position).normalized;
                rb.AddForce(knockBack * Time.fixedDeltaTime * direction);
                player.TakeDamage(enemyDamageAttack);
                Debug.Log("solo si golpeo player");
            }
        }
    }
}
