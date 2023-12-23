using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScriptGG : MonoBehaviour
{
    public int damageAmounts = 5;
 

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            Other.GetComponent<HealthBar>().TakeDamage(damageAmounts);
            
        }

    }
}
