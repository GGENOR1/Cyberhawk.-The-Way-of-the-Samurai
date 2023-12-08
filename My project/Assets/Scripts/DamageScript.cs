using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int DamageAmount = 20;
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy") {
            Other.GetComponent<EnemyScript>().TakeDamage(DamageAmount);
        }
    }
}
