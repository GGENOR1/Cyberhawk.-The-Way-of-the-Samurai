using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttackscript : MonoBehaviour
{
    private Animator Animator;
    private bool IsAttack = false;
    public bool ComboAttack = false;
    public bool CanAttack = true;
    StaminaBar Stamina;
    public GameObject ChildObject;

     void Start()
    {
        Animator = GetComponent<Animator>();
        Stamina = GameObject.FindGameObjectWithTag("Player").GetComponent<StaminaBar>();
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && CanAttack)
        {     
            if (!ComboAttack)
            {
                ComboAttack = true;
                StartAttackAnimation();
                Animator.ResetTrigger("IsAttack");
            }
            else{
                if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
                {
                    Invoke("ContinueComboAttack", 0.3f);
                }
            }
        }
    }

    private void StartAttackAnimation()
    {
        if (ComboAttack)
        {
            Animator.SetTrigger("IsAttack1");
        }
    }

    private void ContinueComboAttack()
    {
        Animator.SetTrigger("IsAttack");
    }
}

