using System.Collections;
using UnityEngine;

public class RangeCircleBlast : MonoBehaviour
{
    public int numSegments = 32;
    public LineRenderer lineRenderer;
    public float rotationSpeed = 1f;
    InstantiateOnClickFire instantiateOnClickFire;
    private Transform player;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numSegments + 1;
        lineRenderer.useWorldSpace = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.position = player.position;
        instantiateOnClickFire = GetComponentInParent<InstantiateOnClickFire>();

    }

    private void Update()
    {
  
        float range = instantiateOnClickFire.range;
        transform.position = player.position;
        float x;
        float y;
        float z = 0f;
        float angle = 20f;
        if (lineRenderer != null)
        {
            for (int i = 0; i < (numSegments + 1); i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * range;
                y = Mathf.Cos(Mathf.Deg2Rad * angle) * range;

                lineRenderer.SetPosition(i, new Vector3(x, y, z));
                lineRenderer.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                angle += (360f / numSegments);
            }
        }

    }
}
