using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.VisualScripting;

public class EnemyScript : MonoBehaviour
{
    Animator Anim;
    public float HP = 100;
    public Slider HealthBar;
    NavMeshAgent Agent;
    Rigidbody[] rb;
    
    BoxCollider BC;
    public bool IsDeathEnemy = false;
    private void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        Agent = Anim.GetComponent<NavMeshAgent>();
        rb = GetComponentsInChildren<Rigidbody>();
        BC = GetComponent<BoxCollider>();
        
    }

    void Update()
    {
        
        HealthBar.value = HP;
        if(HP < 0 & !IsDeathEnemy)
        {
            
            StartCoroutine(Death());
        }
    }

    public void TakeDamage(int DamageAmount) {
        if (HP >= 0 & !IsDeathEnemy)
        {
            HP -= DamageAmount;
            Debug.Log(HP);
        }
    }



    IEnumerator Death()
    {
        Anim.SetBool("IsDeath", true);
        yield return new WaitForSeconds(4f);
        IsDeathEnemy = true;
        
     
        Anim.SetBool("IsDeath", false);
        Anim.enabled = false;
        Agent.enabled = false;

        BC.enabled = false;
        foreach (Rigidbody rb2 in rb)
        {
            rb2.isKinematic = false;
            rb2.useGravity = false;
        }
        
    }
}
