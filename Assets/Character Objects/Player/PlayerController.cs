using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    private Vector2 movementInput;
    private Rigidbody2D rb;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (UpgradeVariables.upgradePlayerSpeed)
        {
            moveSpeed = 1.2f;
        }
    }

    private void FixedUpdate()
    {
        // If movement input is not 0, try to move
        if (movementInput != Vector2.zero)
        {
            TryMove(movementInput);
            animator.SetBool("IsWalking", true);
            /*
            bool success = TryMove(movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }
            animator.SetBool("IsWalking", success);
            */
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private bool TryMove(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        return true;
        /*
        // check for potential collisions
        int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                (moveSpeed) * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
        */
    }


    void OnMove(InputValue movementValue)
    {
        if (!PauseMenu.IsGamePaused)
        {
            movementInput = movementValue.Get<Vector2>();

            // only set the animation direction if the player is trying to move
            if (movementInput != Vector2.zero)
            {
                animator.SetFloat("XInput", movementInput.x);
                animator.SetFloat("YInput", movementInput.y);
            }
        }
    }
}
