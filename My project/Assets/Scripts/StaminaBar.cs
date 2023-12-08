using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public float Stamina = 100f;
    public float MaxStamina = 100f;
    public float MinStamina = 100f;
    public Image Bar;
    public bool CheckStaminaVar = true;
    Move_main MoveState;
    TestAttackscript ComboAttack;
    void Start()
    {
        MoveState = GameObject.FindGameObjectWithTag("Player").GetComponent<Move_main>();
        ComboAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<TestAttackscript>();
    }

    void Update()
    {
        CheckStamina();
    }
     public void DecreasedStamina(float Decreased )
    {
        Stamina -= Decreased;
        Bar.fillAmount = Stamina/100f;
        if (Stamina < MinStamina) Stamina = MinStamina;
    }
    public void IncreasedStamina(float Increased)
    {
        Stamina += Increased;
        Bar.fillAmount = Stamina / 100f;
        if ( Stamina > MaxStamina ) Stamina = MaxStamina;
    }

    public void CheckStamina()
    {
        if(Stamina < MinStamina + 10 ) 
        {
            CheckStaminaVar = true;
            MoveState.CanJump = false;
            ComboAttack.CanAttack = false;
            MoveState.IsRolling = true;
        }
        if (Stamina > MinStamina + 10 && CheckStaminaVar)
        {
            MoveState.CanJump = true;
            ComboAttack.CanAttack = true;
            MoveState.IsRolling = false;
            CheckStaminaVar = false;
        }
    }
}
