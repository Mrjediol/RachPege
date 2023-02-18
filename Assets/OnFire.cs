using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFire : MonoBehaviour
{
    public bool onFire;
    public AniquilationLimit aniquilationLimit;

    public void Limit()
    {  
            onFire = true;
            aniquilationLimit.OnObjectBurn();
    }
}
