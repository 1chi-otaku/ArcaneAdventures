using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] private BoxCollider2D coll;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

   

    float dirX = 0f;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 14f;
    [SerializeField] private float jumpForce = 24f;

    private enum MovementState {idle, running,jumping,falling}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite= GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX* moveSpeed, rb.velocity.y);

       
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);

    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);
    }
}
