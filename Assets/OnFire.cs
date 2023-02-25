using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFire : MonoBehaviour
{
    public bool onFire;
    public AniquilationLimit aniquilationLimit;
    public Sprite newSprite;
    private void Start()
    {
        
    }
    public void Limit()
    {  
        onFire = true;
        aniquilationLimit.OnObjectBurn();
        if (newSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        FindObjectOfType<AudioManager>().Play("AniquilationLimit");
    }
}
