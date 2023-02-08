using System.Collections;
using UnityEngine;

public class RangeCircle : MonoBehaviour
{
    public int numSegments = 32;
    public LineRenderer lineRenderer;
    public float rotationSpeed = 1f;
    InstantiateOnClickVoid instantiateOnClickVoid;
    private Transform player;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numSegments + 1;
        lineRenderer.useWorldSpace = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = player.position;
        instantiateOnClickVoid = GetComponentInParent<InstantiateOnClickVoid>();

    }

    private void Update()
    {
        float range = instantiateOnClickVoid.range;
        transform.position = player.position;
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (numSegments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * range;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * range;

            lineRenderer.SetPosition(i, new Vector3(x, y, z));
            lineRenderer.transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
            angle += (360f / numSegments);
        }

    }
}
