using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPopUp : MonoBehaviour
{
    public GameObject textTodestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(textTodestroy);
        }
    }

}
