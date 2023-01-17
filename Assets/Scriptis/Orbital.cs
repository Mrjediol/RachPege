using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbital : MonoBehaviour
{
    public Transform player;

    public float velocidad;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround((player.transform.position), Vector3.forward, velocidad * Time.deltaTime);
    }
}
