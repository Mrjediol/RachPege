using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolVoid : MonoBehaviour
{
    public static ObjectPoolVoid instance;

    private List<GameObject> pooledObjetcs = new List<GameObject>();
    private int amountToPool = 2;

    [SerializeField]
    private GameObject Prefab;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(Prefab);
            obj.SetActive(false);
            pooledObjetcs.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjetcs.Count; i++)
        {
            if (!pooledObjetcs[i].activeInHierarchy)
            {
                return pooledObjetcs[i];
            }

        }
        return null;
    }
}
