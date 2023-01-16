
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float Cd;
    public GameObject prefabToSpawn;

    private float heat;

    [Range(1, 100)]
    public int range = 5;
    private void Start()
    {
        heat = Cd;
    }

    // Update is called once per frame
    void Update()
    {
        heat -= Time.deltaTime;
        if (heat <= 0)
        {
            Spawn(prefabToSpawn);
            heat = Cd;
        }
    }
    void Spawn(GameObject prefabToSpawn)
    {
        int randomLevel = UnityEngine.Random.Range(1, range);
        Enemy enemy = FindObjectOfType<Enemy>();
        GameObject spawnedEnemy = Instantiate(prefabToSpawn, transform.position, transform.rotation);
        spawnedEnemy.GetComponent<Enemy>().enemyLvl = randomLevel;

        //Instantiate(
        //    prefabToSpawn,
        //    transform.position,
        //    transform.rotation
        //    );

    }

}
