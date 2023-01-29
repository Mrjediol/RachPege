using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    public Vector2 movementDirection;
    public Vector2 direction;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    [SerializeField] private AudioSource swordAttackSound;
    public bool hasPlayedSound = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hasPlayedSound = false;
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
            
        }

        if (movementInput.y < 0)
        {
            animator.SetBool("movingDown", true);
            spriteRenderer.flipX = false;
            //Debug.Log("moviendome a abajo");
        }
        else if (movementInput.y > 0)
        {
            animator.SetBool("movingUp", true);
            spriteRenderer.flipX = false;
            //Debug.Log("moviendome arriba");
        }
        else
        {
            animator.SetBool("movingUp", false);
            animator.SetBool("movingDown", false);
            //Debug.Log("no me muevo ni arriba ni abajo");

        }


        if (movementInput.x < 0)
        {
            animator.SetBool("IsMoving", true);
            spriteRenderer.flipX = true;
            //Debug.Log("moviendome a la izquierda");
        }
        else if (movementInput.x > 0)
        {
            animator.SetBool("IsMoving", true);
            spriteRenderer.flipX = false;
            //Debug.Log("moviendome a la derecha");
        }
        else
        {
            animator.SetBool("IsMoving", false);
            
        }

    }
    public bool TryMove(Vector2 direction)
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
        //if (!hasPlayedSound)
        //{
        //    swordAttackSound.Play();
        //    hasPlayedSound = true;
        //}
        animator.SetTrigger("swordAttack");
        //Debug.Log("fire pressed");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ManaStart" )
        {
            ManaSystem mana = GetComponent<ManaSystem>();
            ManaValue manaValue = other.GetComponent<ManaValue>();
            if(mana.maxMana > mana.currentMana)
            {
                float amountToAdd = Mathf.Min(manaValue.manaValue, mana.maxMana - mana.currentMana);
                mana.currentMana +=amountToAdd;
                manaValue.CreateFloatingText();
                Destroy(other.gameObject);
            } 
        }
    }
    public void PlayAnimation(string animation)
    {
        if (!hasPlayedSound)
        {
            swordAttackSound.Play();
            hasPlayedSound = true;
        }
        animator.Play(animation);
    }

    public void OnAnimationEnd()
    {
        hasPlayedSound = false;
    }

    public void SwordAttack()
    {
        SlowMovement();

        if (spriteRenderer.flipX == true)
        {
            //Debug.Log("atack left");
            swordAttack.AttackLeft();
        }
        else
        {
            //Debug.Log("atack right");
            swordAttack.AttackRight();
        }
    }

    public void EndSwordAttack()
    {
        swordAttack.StopAttack();
    }
    public void SlowMovement()
    {
        moveSpeed = moveSpeed = 0.25f;
        //Debug.Log("slower");
    }
    public void NormalMovement()
    {
        moveSpeed = 1f;
       EndSwordAttack();
        //Debug.Log("que");
    }
    
}
