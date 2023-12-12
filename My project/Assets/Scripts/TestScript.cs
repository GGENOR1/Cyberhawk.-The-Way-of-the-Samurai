using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    StaminaBar Stamina;
    Move_main MoveState;
    TestAttackscript ComboAttack;
    HealthBar CanTakeDamage;

    void Start()
    {
        MoveState = GameObject.FindGameObjectWithTag("Player").GetComponent<Move_main>();
        ComboAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<TestAttackscript>();
        Stamina = GameObject.FindGameObjectWithTag("Player").GetComponent<StaminaBar>();
        CanTakeDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
    }

    public void LookMove() {

        MoveState.IsMove = false;
    }
    public void UnlookMove()
    {
        MoveState.IsMove = true;
    }
    public void LookRoll()
    {
        MoveState.IsRolling = true;
    }
    public void UnlookRoll()
    {
        MoveState.IsRolling = false;
    }
    public void LookAttack()
    {
        Stamina.DecreasedStamina(1f);
        ComboAttack.ComboAttack = true;
    }
    public void UnlookAttack()
    {
        ComboAttack.ComboAttack = false;
    }

    public void LookAttack1()
    {
        ComboAttack.CanAttack = false;
    }
    public void UnlookAttack1()
    {
        ComboAttack.CanAttack = true;
    }
    public void UnlookCanTakeDamage()
    {
      
        CanTakeDamage.CanTakeDamage = true;
    }

    public void LookCanTakeDamage()
    {
        CanTakeDamage.CanTakeDamage = false;
    }

    public void LookJump()
    {
        MoveState.CanJump = false;
        Stamina.DecreasedStamina(15f);
    }

    public void UnlookJump()
    {
        MoveState.CanJump = true;
    }
    public void ActivateTriggerAttack()
    {   
        ComboAttack.ChildObject.GetComponent<MeshCollider>().isTrigger = true;
    }
    public void DiactivateTriggerAttack() 
    { 
        ComboAttack.ChildObject.GetComponent<MeshCollider>().isTrigger = false; 
    }

}
