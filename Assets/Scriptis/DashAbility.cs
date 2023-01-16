
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public float dashSpeed = 20f;
    public Vector2 movementDirection;
    public float dashCooldown = 1.0f;
    private float currentCooldown = 0.0f;
    private bool onCooldown = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (onCooldown)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0)
            {
                onCooldown = false;
                currentCooldown = 0;
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!onCooldown)
            {
                onCooldown = true;
                currentCooldown = dashCooldown;
                rb.MovePosition(rb.position + movementDirection * dashSpeed * Time.deltaTime);
            }
        }
    }
}