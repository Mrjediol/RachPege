
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
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashing = true;
            dashTimer = dashTime;
        }

        if (isDashing)
        {
            if (dashTimer > 0)
            {

                rb.AddForce((Vector3)movementDirection * dashSpeed * Time.deltaTime);
                dashTimer -= Time.deltaTime;
            }
            else
            {
                isDashing = false;
            }
        }
    }
}