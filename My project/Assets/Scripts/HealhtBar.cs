using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float HP = 100f;
    public float MaxHealth = 100f;
    public float MinHealth = 100f;
    public Image Bar;
    public bool CheckHealthVar = true;
    Move_main MoveState;
    TestAttackscript ComboAttack;
    public bool CanTakeDamage = true;

    Animator Anim;
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        MoveState = GameObject.FindGameObjectWithTag("Player").GetComponent<Move_main>();
        ComboAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<TestAttackscript>();
    }

    void Update()
    {
        ChechHP();
    }


    public void TakeDamage(int DamageAmount)
    {
        if (HP >= 0 & CanTakeDamage)
        {
            HP -= DamageAmount;
            //Debug.Log("ХП героя" + HP);
            Bar.fillAmount = HP / 100f;
        }
        if (HP <= 0 )
        {
            StartCoroutine(LoadMainMenu());
        }
    }

    public void ChechHP()
    {
        if (HP <= 0)
        {
            Anim.SetBool("IsDeath", true);
        }
    }


    IEnumerator LoadMainMenu()
    {

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
        


}
