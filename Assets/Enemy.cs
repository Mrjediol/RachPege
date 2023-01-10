using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float Health
    {
        set
        {
            Health = value;
            if(Health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return Health;
        }
    }

    public float health = 1;


    public void Defeated()
    {
        Destroy(gameObject);
    }

}
