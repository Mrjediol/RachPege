using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public string tagTarget = "Player";

    public List<Collider2D> detectedObjs = new List<Collider2D>();

    public Collider2D col;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Add(collider);

            Debug.Log("voy a por ti");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Remove(collider);
        }
    }

    public void AccessDetectedObjs(int index)
    {
        // Check if the list is empty before trying to access an element
        if (detectedObjs.Count > 0)
        {
            // Check if the index is within the valid range
            if (index < detectedObjs.Count)
            {
                // Access element in the list
                Collider2D obj = detectedObjs[index];
                // Do something with the element
            }
            else
            {
                Debug.LogError("Index out of range. The index must be less than the size of the collection.");
            }
        }
        else
        {
            Debug.LogError("List is empty. There are no elements to access.");
        }
    }
}