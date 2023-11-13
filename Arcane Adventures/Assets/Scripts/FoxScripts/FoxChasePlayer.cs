using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxChasePlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float chaseSpeed = 0.5f;
    public float stoppingDistance = 1f;
    public Animator animator;
    public SpriteRenderer sr;

    private Vector3 moveDirection;
    private bool isChasing;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > stoppingDistance)
        {
            isChasing = true;
            moveDirection = new Vector3(
                playerTransform.position.x - transform.position.x,
                0.0f,
                playerTransform.position.z - transform.position.z
            ).normalized;

            transform.Translate(moveDirection * chaseSpeed * Time.deltaTime, Space.World);
        }
        else if (distanceToPlayer <= stoppingDistance)
        {
            isChasing = false;
            moveDirection = Vector3.zero;
        }

        if (moveDirection.x < 0)
            sr.flipX = true;
        else if (moveDirection.x > 0)
            sr.flipX = false;

        animator.SetFloat("Speed", isChasing ? chaseSpeed : 0f);
    }
}
