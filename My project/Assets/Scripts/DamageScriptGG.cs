using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScriptGG : MonoBehaviour
{

    public int DamageAmount = 20;
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            Debug.Log("���");
            Other.GetComponent<HealthBar>().TakeDamage(DamageAmount);
     
        }

    }
}
