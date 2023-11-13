using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    float dirX = 0f;

    [SerializeField] private float moveSpeed = 14f;
    [SerializeField] private float jumpForce = 24f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite= GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX* moveSpeed, rb.velocity.y);

       
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (dirX > 0)
        {
            animator.SetBool("IsRunning", true);
            sprite.flipX = false;

        }
        else if (dirX < 0)
        {
            animator.SetBool("IsRunning", true);
            sprite.flipX = true;
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
}
