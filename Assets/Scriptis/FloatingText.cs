using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float timeToLive = 0.5f;
    public float floatSpeed = 300f;
    public Vector3 floatDirection = new Vector3(0, 1, 0);
    public TextMeshProUGUI textMesh;
    RectTransform rectTransform;
    Color startingColor;
    float timeElapsed = 0.0f;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        startingColor = textMesh.color;
        rectTransform = GetComponent<RectTransform>();

    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        rectTransform.position += floatDirection * floatSpeed * Time.deltaTime;
        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed / timeToLive));

        if (timeElapsed > timeToLive)
        {
            Destroy(gameObject);
        }
    }





}
