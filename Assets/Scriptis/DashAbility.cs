using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public float dashSpeed = 20f;
    public Vector2 movementDirection;
    private bool isDashing;
    public float dashTime = 0.2f;
    private float dashTimer;
    public float cooldown = 0.5f;
    private float cooldownTimer;
    public bool isUnlocked = false;
    public int levelRequirement = 5;
    Rigidbody2D rb;
    AudioManager audioManager;
    public bool hasPlayedSound;
    public TrailRenderer trailRenderer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Time.timeScale == 0)
            return;
        if (isUnlocked && Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0)
        {
            isDashing = true;
            trailRenderer.emitting = true;
            dashTimer = dashTime;
            cooldownTimer = cooldown;
            hasPlayedSound = false;
        }

        if (isDashing)
        {
            if (dashTimer > 0)
            {
                if (!hasPlayedSound) 
                {
                    audioManager.Play("Dash");
                    hasPlayedSound = true;

                }

                rb.AddForce((Vector3)movementDirection * dashSpeed * Time.deltaTime);
                dashTimer -= Time.deltaTime;
            }
            else
            {
                isDashing = false;
                Invoke("StopEmitting", 0.1f);

               
            }
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }
    void StopEmitting()
    {
        trailRenderer.emitting = false;
    }

    public void Unlock()
    {
        isUnlocked = true;
    }

    public void Lock()
    {
        isUnlocked = false;
    }
}
