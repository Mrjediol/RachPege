using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public GameObject deathScreen;
    public Vector3 currentSpawnPoint;
    public bool isDead;
    private Color deathScreenColor;

    private void Start()
    {
        LoadCheckPoint();
        deathScreenColor = deathScreen.GetComponentInChildren<Image>().color;
        transform.position = currentSpawnPoint;
    }
    // Llamado cuando el jugador muere
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CheckPoint"))
        {
            currentSpawnPoint = transform.position;
            SaveCheckPoint();
        }
    }
    public void SaveCheckPoint()
    {
        PlayerPrefs.SetFloat("currentSpawnPoint.x", currentSpawnPoint.x);
        PlayerPrefs.SetFloat("currentSpawnPoint.y", currentSpawnPoint.y);
        PlayerPrefs.SetFloat("currentSpawnPoint.z", currentSpawnPoint.z);
        PlayerPrefs.Save();
    }
    public void LoadCheckPoint()
    {
        float x = PlayerPrefs.GetFloat("currentSpawnPoint.x");
        float y = PlayerPrefs.GetFloat("currentSpawnPoint.y");
        float z = PlayerPrefs.GetFloat("currentSpawnPoint.z");
        currentSpawnPoint = new Vector3(x, y, z);
    }
    public void PlayerDeath()
    {
        // Desactivar el controlador del jugador y el modelo del jugador
        GetComponent<PlayerController>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerHealth>().enabled = false;
        isDead = true;
        // Activar la pantalla de muerte
        deathScreen.SetActive(true);

        // Esperar 3 segundos antes de hacer que el jugador reaparezca
        StartCoroutine(RespawnAfterDelay(1f));
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Mover al jugador al punto de spawn actual
        transform.position = currentSpawnPoint;

        // Gradualmente disminuir el alpha de la pantalla de muerte
        while (deathScreenColor.a > 0)
        {
            deathScreenColor.a -= Time.deltaTime / 3f;
            deathScreen.GetComponentInChildren<Image>().color = deathScreenColor;
            yield return null;
        }
        // Reactivar el controlador del jugador y el modelo del jugador
        GetComponent<PlayerHealth>().enabled = true;
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.health = playerHealth.maxhealth;
        }
        GetComponent<PlayerController>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        // Desactivar la pantalla de muerte
        deathScreen.SetActive(false);
        isDead = false;
        // Restaurar el valor original del alpha de la pantalla de muerte
        deathScreenColor.a = 1f;
        deathScreen.GetComponentInChildren<Image>().color = deathScreenColor;
    }
}

