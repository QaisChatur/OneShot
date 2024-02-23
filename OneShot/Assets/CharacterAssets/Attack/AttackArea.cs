using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision detected with: " + collider.gameObject.name);
        Health health = collider.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(damage);
        }
    }

}