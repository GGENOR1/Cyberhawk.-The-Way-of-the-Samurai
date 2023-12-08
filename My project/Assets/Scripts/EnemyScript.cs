using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float HP = 100;
    public Slider HealthBar;

    void Update()
    {
        HealthBar.value = HP;
    }

    public void TakeDamage(int DamageAmount) { 
         HP -= DamageAmount;
        Debug.Log(HP);
    }
}
