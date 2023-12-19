using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : StateMachineBehaviour
{
    Transform player;
    Rigidbody rb;
    public float speed = 1.5f;
    Boss boss;
    public float attackRange = 0.7f;
    public float timeBtwAttack = 0;
    float starttimeBtwAttack = 1f;
    float timeBtwLaserAttack = 5f;
    float starttimeBtwLaserAttack = 5f;
    bool state = false;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody>();
        boss = animator.GetComponent<Boss>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        state = boss.secondpart;
        if (Vector3.Distance(player.position, rb.position) > attackRange * 3)
        {
            if (timeBtwAttack <= 0)
            {
                animator.SetTrigger("RangeAttack");
                timeBtwAttack = starttimeBtwAttack;
            }
            else
            {
                Vector3 target = new Vector3(player.position.x, player.position.y, player.position.z);
                Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.deltaTime);
                rb.MovePosition(newPos);
                timeBtwAttack -= Time.deltaTime;
                timeBtwLaserAttack -= Time.deltaTime;
            }
        }
        else if (Vector3.Distance(player.position, rb.position) < 1.5 && state == true && timeBtwLaserAttack <= 0)
        {
            animator.SetTrigger("Laser");
            timeBtwLaserAttack = starttimeBtwLaserAttack;

        }
        else if (Vector3.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
            timeBtwLaserAttack -= Time.deltaTime;

        }
        else
        {
            Vector3 target = new Vector3(player.position.x, player.position.y, player.position.z);
            Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.deltaTime);
            timeBtwLaserAttack -= Time.deltaTime;
            rb.MovePosition(newPos);

        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


}
