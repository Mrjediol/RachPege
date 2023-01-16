
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public float dashSpeed = 20f;
    public Vector2 movementDirection;
    private bool isDashing;
    private float dashTime = 0.2f;
    private float dashTimer;

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
                transform.position = transform.position + (Vector3)movementDirection * dashSpeed * Time.deltaTime;
                dashTimer -= Time.deltaTime;
            }
            else
            {
                isDashing = false;
            }
        }
    }
}