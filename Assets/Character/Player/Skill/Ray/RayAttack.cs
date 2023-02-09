using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float range = 5f;
    public LayerMask enemyMask;
    public Transform player;
    public LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(player.position, ray.direction, out hit, range, enemyMask))
        {
            CastRay(hit.point, hit.distance);
        }
        else
        {
            lineRenderer.SetPositions(new Vector3[] { player.position, ray.GetPoint(range) });
            TeleportPlayer(ray.GetPoint(range));
        }
    }

    void CastRay(Vector3 origin, float distance)
    {
        Ray ray = new Ray(origin, (player.position - origin).normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, enemyMask))
        {
            CastRay(hit.point, hit.distance);
        }
        else
        {
            lineRenderer.SetPositions(new Vector3[] { player.position, ray.GetPoint(distance) });
            TeleportPlayer(ray.GetPoint(distance));
        }
    }

    void TeleportPlayer(Vector3 position)
    {
        player.position = position;
    }
}


public class RayAttack : MonoBehaviour
{
    public float range = 5f;
    public LayerMask enemyMask;
    public Transform player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(player.position, ray.direction, out hit, range, enemyMask))
        {
            CastRay(hit.point, hit.distance);
        }
        else
        {
            TeleportPlayer(ray.GetPoint(range));
        }
    }

    void CastRay(Vector3 origin, float distance)
    {
        Ray ray = new Ray(origin, (player.position - origin).normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, enemyMask))
        {
            CastRay(hit.point, hit.distance);
        }
        else
        {
            TeleportPlayer(ray.GetPoint(distance));
        }
    }

    void TeleportPlayer(Vector3 position)
    {
        player.position = position;
    }
}
