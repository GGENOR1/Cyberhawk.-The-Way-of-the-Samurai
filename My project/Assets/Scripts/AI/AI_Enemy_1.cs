using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class AI_Enemy_1 : MonoBehaviour
{
    private Animator Animator;
    private NavMeshAgent AIAgent;
    private GameObject Player;
    public float WaitSecondAttack = 5.0f;
    public bool CanMoveEnemy = true;
    public bool CanAttackEnemy = true;
    void Start()
    {
        AIAgent = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Animator = gameObject.GetComponent<Animator>(); 
    }

    void FixedUpdate()
    {
        if (CanMoveEnemy)
        {
            //Animator.SetFloat("speed", 1f);
            AIAgent.SetDestination(Player.transform.position);
        //    float Dist_Player = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        //    if (Dist_Player < 3 & CanAttackEnemy)
        //    {
        //        StartCoroutine(Attack());
        //    }
        }
    }


    //IEnumerator Attack()
    //{
    //    Animator.SetFloat("speed", 0);
    //    CanAttackEnemy = false;
    //    CanMoveEnemy = false;
    //    Animator.SetTrigger("IsAttackEnemy");
    //    Animator.SetFloat("speed", 0.3f);
    //    yield return new WaitForSeconds(WaitSecondAttack);
    //    CanMoveEnemy = true;
        
    //    yield return new WaitForSeconds(WaitSecondAttack);
    //    CanAttackEnemy = true;
        
        
    //}
}
