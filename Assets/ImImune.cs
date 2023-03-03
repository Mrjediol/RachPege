using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImImune : MonoBehaviour
{
  
    public GameObject isInmuneScreem;
    // Start is called before the first frame update
    public void InmuneShow(Collider2D collision)
    {

            isInmuneScreem.SetActive(true);
           
        
    }
    public void SetNormalTime()
    {
        Time.timeScale = 1f;
    }
}
