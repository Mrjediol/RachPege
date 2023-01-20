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
    [SerializeField] private AudioSource dashSoundEffect;
    public bool hasPlayedSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (isUnlocked && Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0)
        {
            isDashing = true;
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
                    dashSoundEffect.Play();
                    hasPlayedSound = true;

                }

                rb.AddForce((Vector3)movementDirection * dashSpeed * Time.deltaTime);
                dashTimer -= Time.deltaTime;
            }
            else
            {
                isDashing = false;
            }
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
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
