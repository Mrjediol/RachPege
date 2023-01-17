using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public float timetolive = 5f;
    public float floatSpeed = 0.1f;

    public Vector3 floatDirection = new Vector3(0, 1, 0);

    public TextMeshProUGUI textMesh;
    Color startingColor;
    RectTransform rectTransform;

    float timeElapsed = 0.0f;

    private void Start()
    {

        rectTransform = GetComponent<RectTransform>();
        startingColor = textMesh.color;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        rectTransform.position += floatDirection * floatSpeed * Time.deltaTime;
        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed / timetolive));

        if (timeElapsed > timetolive)
        {
            Destroy(gameObject);
        }
    }
}
