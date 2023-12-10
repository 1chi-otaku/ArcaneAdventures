using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : StateMachineBehaviour
{
    Transform player;
    Rigidbody rb;
    public float speed =2.5f;
    Boss boss;
    public float attackRange = 0.5f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb =animator.GetComponent<Rigidbody>();
        boss = animator.GetComponent<Boss>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        if (Vector3.Distance(player.position, rb.position) > attackRange*3)
        {
            animator.SetTrigger("RangeAttack");
        }
        else if (Vector3.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            Vector3 target = new Vector3(player.position.x, player.position.y, player.position.z);
            Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


}
