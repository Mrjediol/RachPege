using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    InstantiateAniquilation instantiateAniquilation;
    void Start()
    {
        instantiateAniquilation = GetComponentInParent<InstantiateAniquilation>();
    }

    private void OnDestroy()
    {
        instantiateAniquilation.Explotion();
    }
}
