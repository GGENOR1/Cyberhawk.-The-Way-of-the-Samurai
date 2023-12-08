using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    BoxCollider triggerBox;

    private void Start()
    {
        triggerBox = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.HP-= damage;
            if(enemy.HP < 0)
            {
                Destroy(enemy);
            }

        }
    }
    public void EnableTriggerBox() { 
        triggerBox.enabled = true;
    }
    public void DisableTriggerBox()
    {
        triggerBox.enabled = false;
    }

}
