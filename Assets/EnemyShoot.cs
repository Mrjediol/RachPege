using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject electricPrefab;
    public Transform nuzle;
    PlayerController playerController;
    
    public Vector3 startposition;
    public Vector3 leftposition;
    
    LookPlayer lookPlayer;

    public float force = 1f;
    public float damge = 10f;
    public float cooldown = 3f;
    private float nextFireTime;
    public Vector3 scale = new(0.1f, 0.1f, 0.1f);
    
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        startposition = nuzle.position;
        lookPlayer = GetComponent<LookPlayer>();
        nextFireTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookPlayer.MovingLeft == true) 
        {
            nuzle.position = transform.position + new Vector3(-0.15f, 0f, 0f);
        }
        else
        {
            nuzle.position = transform.position + new Vector3(0.15f, 0f, 0f);
        }
    }
    public void EnemyDash()
    {
        if (lookPlayer.MovingLeft == true)
        {
            transform.position = transform.position + new Vector3(0.44f, 0f, 0f);
        }
        else
        {
            transform.position = transform.position + new Vector3(-0.44f, 0f, 0f);
        }
    }
    public void ShootPlayer()
    {
        if (Time.time > nextFireTime)
        {

            Vector3 direction = (playerController.transform.position - nuzle.position).normalized;
            GameObject instantiatePrefab = Instantiate(electricPrefab, nuzle.position, Quaternion.identity);
            Rigidbody2D rb = instantiatePrefab.GetComponent<Rigidbody2D>();
            instantiatePrefab.transform.parent = transform;
            instantiatePrefab.transform.localScale = scale;
            rb.AddForce(direction * force, ForceMode2D.Impulse);
            Destroy(instantiatePrefab, 1f);
            nextFireTime = Time.time + cooldown;
        }
    }
}
