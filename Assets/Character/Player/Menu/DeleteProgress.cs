using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteProgress : MonoBehaviour
{


    // Update is called once per frame
    public void DeleteProgres()

    {
        PlayerPrefs.DeleteAll();
    }
}
