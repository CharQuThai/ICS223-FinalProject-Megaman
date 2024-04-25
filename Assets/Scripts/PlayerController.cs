using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;

    [SerializeField] float moveSpeed = 6.0f;
    [SerializeField] float jumpSpeed = 8.0f;

    bool isGrounded;
    bool isFacingRight = true;

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void Update()
    {
        HandleInput();
        UpdateAnimations();
    }

    void CheckGrounded()
    {
        isGrounded = false;
        RaycastHit2D raycastHit;
        float raycastDistance = 0.05f;
        int layerMask = 1 << LayerMask.NameToLayer("Ground");

        Vector3 box_origin = boxCollider.bounds.center;
        Vector3 box_size = boxCollider.bounds.size;
        box_origin.y = boxCollider.bounds.min.y + (boxCollider.bounds.extents.y / 4.0f);
        box_size.y = boxCollider.bounds.size.y / 4.0f;
        raycastHit = Physics2D.BoxCast(box_origin, box_size, 0.0f, Vector2.down, raycastDistance, layerMask);

        if (raycastHit.collider != null)
        {
            isGrounded = true;
        }
    }

    void HandleInput()
    {
        float keyHor = Input.GetAxisRaw("Horizontal");
        bool keyJump = Input.GetKeyDown(KeyCode.Space);
        bool keyShoot = Input.GetKeyDown(KeyCode.P);

        // Move left or right
        float moveDirection = keyHor;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Flip sprite if needed
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !isFacingRight || moveDirection < 0 && isFacingRight)
            {
                Flip();
            }
        }

        // Jump
        if (keyJump && isGrounded)
        {
            Jump();
        }

        // Shoot
        if (keyShoot)
        {
            Shoot();
        }
    }

    void UpdateAnimations()
    {
        if (isGrounded)
        {
            if (rb.velocity.x != 0)
            {
                animator.SetBool("IsRunning", true);
            }
            else
            {
                animator.SetBool("IsRunning", false);
            }
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        animator.SetBool("IsGrounded", isGrounded);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}