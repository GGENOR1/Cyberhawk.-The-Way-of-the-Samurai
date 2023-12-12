using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    //HealthBar HealthBar;

    //public void Start()
    //{
    //    HealthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
    //}
    public int DamageAmount = 20;
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy") {
            Other.GetComponent<EnemyScript>().TakeDamage(DamageAmount);
        }

    }
}
