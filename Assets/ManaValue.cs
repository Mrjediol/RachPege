using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManaValue : MonoBehaviour
{
    public float manaValue = 50;
    public TextMeshProUGUI manaValueImg;
    public float timeToLive = 10;
    public float scaleFactor = 1;
    public float minScale = 0.8f;
    public float maxScale = 1.2f;
    public float minTimeToLive = 5f;
    public float maxTimeToLive = 15f;

    private void Start()
    {

        manaValueImg = GetComponentInChildren<TextMeshProUGUI>();
        manaValueImg.text = "+ " + manaValue;

        // Escala la transformación en función de la cantidad de maná
        float targetScale = minScale + (maxScale - minScale) * (manaValue - 50f) / (500f - 50f);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale * Vector3.one, scaleFactor);

        // El tiempo de vida también se ajusta en función de la cantidad de maná
        float targetTimeToLive = minTimeToLive + (maxTimeToLive - minTimeToLive) * (manaValue - 50f) / (500f - 50f);
        timeToLive = Mathf.Lerp(timeToLive, targetTimeToLive, scaleFactor);
        Destroy(gameObject, timeToLive);
    }
}
