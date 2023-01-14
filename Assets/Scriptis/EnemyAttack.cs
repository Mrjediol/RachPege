/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{


    public float damage = 3;
    Vector2 enemyAttackOffset;

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
        if (collision.gameObject.tag == "Enemy")
        {
            // Deal damage to the player
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                Debug.Log("Hago Daño al player");

                player.Health -= enemyDamage;
            }
        }
    }
    
}*/
