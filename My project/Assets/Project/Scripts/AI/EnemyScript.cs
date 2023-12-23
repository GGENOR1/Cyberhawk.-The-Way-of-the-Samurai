using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.VisualScripting;

public class EnemyScript : MonoBehaviour
{
    Animator anim;
    public float HP = 100;
    public Slider healthBar;
    NavMeshAgent agent;
    Rigidbody[] rb;
    public Vector3 startPoint;
    //BoxCollider BC;
    CapsuleCollider BC;
    public bool isDeathEnemy = false;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        agent = anim.GetComponent<NavMeshAgent>();
        rb = GetComponentsInChildren<Rigidbody>();
        BC = GetComponent<CapsuleCollider>();
        startPoint = GetComponent<Transform>().transform.position;
    }

    void Update()
    { 
        healthBar.value = HP;
        if(HP <= 0 & isDeathEnemy)
        {
            StartCoroutine(Death());
        }
    }

    public void TakeDamage(int DamageAmount) {
        if (HP > 0 & !isDeathEnemy)
        {
            HP -= DamageAmount;
        }
    }
    public void LookTrigers()
    {
        BC.isTrigger = false;
    }

    public void UnlookTrigers()
    {
        BC.isTrigger = true;
    }

    IEnumerator Death()
    {
        //anim.SetBool("IsDeath", true);
        //yield return new WaitForSeconds(4f);
        //isDeathEnemy = true;
        //anim.SetBool("IsDeath", false);
        //anim.enabled = false;
        //agent.enabled = false;
        //BC.isTrigger = true;
        //foreach (Rigidbody rb2 in rb)
        //{
        //    rb2.isKinematic = false;
        //    rb2.useGravity = false;
        //}
        anim.SetBool("IsDeath", true);
        isDeathEnemy = true;
        Destroy(gameObject, 4f);
        yield return null;
    }
}
