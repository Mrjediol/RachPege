using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    public Slider slider;
    public Color low;
    public Color hight;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health <= maxHealth);
        slider.maxValue = maxHealth;

        slider.value = health;



        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, hight, slider.normalizedValue);

    }
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
