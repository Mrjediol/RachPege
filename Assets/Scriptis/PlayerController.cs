using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;


    Vector2 movementInput;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }

        

           /* if (movementInput.y < 0)
            {
                animator.SetBool("movingDown", true);
            }
            else
            {
                animator.SetBool("movingDown", false);
            }
            if (movementInput.y > 0)
            {
                animator.SetBool("movingUp", true);
            }
            else
            {
                Debug.Log("no llego");
                animator.SetBool("movingUp", false);
            }*/
            
        }

        if (movementInput.y < 0)
        {
            animator.SetBool("movingDown", true);

            Debug.Log("moviendome a abajo");
        }
        else if (movementInput.y > 0)
        {
            animator.SetBool("movingUp", true);          
            Debug.Log("moviendome arriba");
        }
        else
        {
            animator.SetBool("movingUp", false);
            animator.SetBool("movingDown", false);
            Debug.Log("no me muevo ni arriba ni abajo");

        }


        if (movementInput.x < 0)
        {
            animator.SetBool("IsMoving", true);
            spriteRenderer.flipX = true;
            Debug.Log("moviendome a la izquierda");
        }
        else if (movementInput.x > 0)
        {
            animator.SetBool("IsMoving", true);
            spriteRenderer.flipX = false;
            Debug.Log("moviendome a la derecha");
        }
        else
        {
            animator.SetBool("IsMoving", false);
            
        }

    }
    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                    direction,
                    movementFilter,
                    castCollisions,
                    moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    private void OnFire()
    {
        animator.SetTrigger("swordAttack");
        Debug.Log("fire pressed");
    }

    public void SlowMovement()
    {
        moveSpeed = moveSpeed/4;
        Debug.Log("slower");
    }
    public void NormalMovement()
    {
        moveSpeed = 1f;
        Debug.Log("que");
    }
    
}
