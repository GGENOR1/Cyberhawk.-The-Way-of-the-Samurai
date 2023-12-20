using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy") {
            Other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }

    }
}
