using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;

public class ManaValue : MonoBehaviour
{
    public float manaValue = 50;
    //public TextMeshProUGUI manaValueImg;
    public float timeToLive = 10;
    public float scaleFactor = 1;
    public float minScale = 0.8f;
    public float maxScale = 1.2f;
    public float minTimeToLive = 5f;
    public float maxTimeToLive = 15f;
    public GameObject manaText;
    //public GameObject manaStarTextPrefab;
    private void Start()
    {

        //manaValueImg = GetComponentInChildren<TextMeshProUGUI>();
        //manaValueImg.text = "+ " + manaValue;

        // Escala la transformación en función de la cantidad de maná
        float targetScale = minScale + (maxScale - minScale) * (manaValue - 50f) / (500f - 50f);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale * Vector3.one, scaleFactor);

        // El tiempo de vida también se ajusta en función de la cantidad de maná
        float targetTimeToLive = minTimeToLive + (maxTimeToLive - minTimeToLive) * (manaValue - 50f) / (500f - 50f);
        timeToLive = Mathf.Lerp(timeToLive, targetTimeToLive, scaleFactor);

        Destroy(gameObject, timeToLive);
    }
    //private void OnDestroy()
    //{
    //    CreateFloatingText();
    //}
    private TextMeshProUGUI floatingText;
    private float speed = 1000f;
    public void CreateFloatingText()
    {
        //GameObject canvasGO = new GameObject("FloatingTextCanvas");
        //canvasGO.transform.position = transform.position + new Vector3(0, 0.2f, 0); ;
        //canvasGO.transform.rotation = transform.rotation;
        //canvasGO.AddComponent<Canvas>();
        //canvasGO.AddComponent<CanvasScaler>();
        //canvasGO.AddComponent<GraphicRaycaster>();

        ///*TextMeshProUGUI */
        //floatingText = new GameObject("floatingText").AddComponent<TextMeshProUGUI>();
        //floatingText.text = "+ " + manaValue;
        //floatingText.transform.SetParent(canvasGO.transform);
        //floatingText.rectTransform.localPosition = Vector3.zero;
        //floatingText.rectTransform.sizeDelta = new Vector2(2.5f, 1f);
        //floatingText.rectTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //floatingText.alignment = TextAlignmentOptions.Center;
        //floatingText.fontSize = 1;

        //Destroy(canvasGO, 1f);
        RectTransform textTransform = Instantiate(manaText).GetComponent<RectTransform>();
        textTransform.GetComponent<TextMeshProUGUI>().text = "+" + manaValue.ToString("F0", new CultureInfo("es-ES"));
        textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        textTransform.SetParent(canvas.transform);
    }
    private void Update()
    {
        if (floatingText != null)
        {
            Debug.Log("floatingText existe");
            floatingText.rectTransform.localPosition -= new Vector3(0, speed * Time.deltaTime, 0);

        }  //GameObject manaStarText = Instantiate(manaStarTextPrefab, transform.position, Quaternion.identity);
    }
}
