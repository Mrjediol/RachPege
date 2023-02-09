using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbital : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 2f;
    public float velocidad;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround((player.transform.position), Vector3.forward, velocidad * Time.deltaTime);
        transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
    }
}
