using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{


    public float enemyDamage = 3;
    Vector2 enemyAttackOffset;
    public Collider2D attackCollider;
    PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        enemyAttackOffset = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Deal damage to the player
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

            if (player != null)
            {
                Debug.Log("Hago Daño al player");

                player.health -= enemyDamage;
                player.TakeDamage();

            }
        }
    }

}
