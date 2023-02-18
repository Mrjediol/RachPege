using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniquilationLimit : MonoBehaviour
{
    private int objectsOnFire = 0;
    public void OnObjectBurn()
    {
        objectsOnFire++;

        if (objectsOnFire == 5)
        {
            Destroy(gameObject);
        }
    }
}
