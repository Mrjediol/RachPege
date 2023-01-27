using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DPS : MonoBehaviour
{
    // Variables para almacenar la vida y el tiempo transcurrido desde el último ataque
    public float health = 100f;
    private float lastAttackTime;
    private float damagePerSecond;
    private TextMeshProUGUI DpsText;

    private void Start()
    {
        DpsText = GameObject.Find("DpsText").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        // Actualizar el tiempo transcurrido desde el último ataque
        lastAttackTime += Time.deltaTime;
    }

    // Función para manejar el daño recibido
    public void TakeDamage(float damage)
    {
        // Restar el daño de la vida
        health -= damage;
        // Calcular el DPS
        damagePerSecond = damage / lastAttackTime;
        lastAttackTime = 0;
        damagePerSecond = Mathf.Round(damagePerSecond * 10) / 10f;
        // Mostrar el DPS en pantalla
        DpsText.text = damagePerSecond + " DPS";
        Debug.Log("DPS: " + damagePerSecond);
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    // Si colisiona con algo, llama a la función de manejo de daño
    //    AttackColliderFire attackColliderFire = collision.gameObject.GetComponent<AttackColliderFire>();
    //    if (attackColliderFire != null)
    //    {
    //        TakeDamage(attackColliderFire.fireDamage);
    //    }
    //}
}