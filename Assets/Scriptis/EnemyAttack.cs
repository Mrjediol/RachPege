using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{


    public float enemyDamageAttack = 3;
    Vector2 enemyAttackOffset;
    public Collider2D attackCollider;
    PlayerHealth playerHealth;
    public float knockBack = 1000f;
    public DetectionZone detectionZone;
    public GameObject playerObject;
    //public GameObject DamageTake;
    // Start is called before the first frame update
    void Start()
    {
        
        enemyAttackOffset = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
        playerObject = GameObject.Find("Player");

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


                //RectTransform textTransform = Instantiate(DamageTake).GetComponent<RectTransform>();
                //textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                //Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                //textTransform.SetParent(canvas.transform);

                Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();

                Vector2 direction = (playerRigidbody.transform.position - transform.position).normalized;

                playerRigidbody.AddForce(knockBack * Time.fixedDeltaTime * direction);

                

               
                player.health -= enemyDamageAttack;
                    player.TakeDamage();

                }
            
        }
    }

}
