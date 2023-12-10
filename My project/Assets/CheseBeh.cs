using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

public class CheseBeh : StateMachineBehaviour
{
    NavMeshAgent Agent;
    Transform Player;
    List<Transform> points = new List<Transform>(); 
    float AttackRange = 2f;
    float ChaseRange = 10f;
    float NoVisibleRange = 15f;

    bool IsAttackingEnrm = false;
    float AttackTimer = 0f;
    float AttackDelay = 5f;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        Agent = animator.GetComponent<NavMeshAgent>();
        Agent.speed = 4;
        Debug.Log(AttackRange);
        foreach (Transform t in pointsObject)
        {
            points.Add(t);
        }
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(Player);
        Agent.SetDestination(points[0].position);

    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
        float Distance = Vector3.Distance(animator.transform.position, Player.position);
        float DistanceToHome = Vector3.Distance(animator.transform.position, points[0].position);
        if (Distance > NoVisibleRange)
        {
            if (DistanceToHome < 1)
            {
                animator.SetFloat("speed", 0f);
            }
            else
            {
                animator.SetFloat("speed", 0.2f);
                Agent.SetDestination(points[0].position);
                Debug.Log("Иду по делам");
            }
        }
        if (IsAttackingEnrm)
        {
            AttackTimer -= Time.deltaTime;
            Debug.Log(AttackTimer);
            if (AttackTimer <= 0)
            {
                IsAttackingEnrm = false;
            }
        }
        if (Distance < AttackRange && !IsAttackingEnrm)
        {

            Agent.SetDestination(Player.position);
            Debug.Log("Надо бить");
            animator.SetBool("IsAttaking", true);
            IsAttackingEnrm = true;
            AttackTimer = AttackDelay;
        }



        if (Distance > AttackRange & NoVisibleRange > Distance)
        {
            Agent.SetDestination(Player.position);
            Debug.Log("Надо бежать");
            animator.SetFloat("speed", 1f);
        }

    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Agent.SetDestination(Agent.transform.position);
        Agent.speed = 2;
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
