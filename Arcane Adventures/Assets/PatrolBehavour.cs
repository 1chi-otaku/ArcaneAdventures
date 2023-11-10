using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PatrolBehavour : StateMachineBehaviour
{
    //float timer;
    //List<Transform> points = new List<Transform>();
    //NavMeshAgent agent;
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    timer = 0;
    //    Transform pointsObject = GameObject.FindGameObjectWithTag("Point").transform;
    //    foreach (Transform point in pointsObject)
    //    {
    //        points.Add(point);
    //    }
    //    agent =animator.GetComponent<NavMeshAgent>();
    //    agent.SetDestination(points[0].position);
    //}

    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if(agent.remainingDistance <= agent.stoppingDistance)
    //    {
    //        agent.SetDestination(points[Random.Range(0, points.Count)].position);
    //    }
    //    timer += Time.deltaTime;
    //    if (timer > 10)
    //    {
    //        animator.SetBool("IsPatrolling", false);

    //    }   
    //}

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    agent.SetDestination(agent.transform.position);
    //}

}
