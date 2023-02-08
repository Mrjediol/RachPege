using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public float range = 5f;
    private SpriteRenderer rangeCircleRenderer;

    private void Start()
    {
        rangeCircleRenderer = GetComponentInChildren<SpriteRenderer>();
        rangeCircleRenderer.transform.localScale = Vector3.one * range * 2;
    }

    private void Update()
    {
        rangeCircleRenderer.transform.position = transform.position;
    }
}
