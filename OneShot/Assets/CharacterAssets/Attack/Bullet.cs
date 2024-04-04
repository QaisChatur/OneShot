using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health enemy = collision.gameObject.GetComponent<Health>();

        if (enemy != null)
        {
            enemy.Damage(3);
            if (enemy.IsDead()) // Check if the enemy is dead
            {
                GameObject.FindWithTag("Player").GetComponent<Shooting>().AllowShooting();
            }
        }
        Destroy(gameObject);
    }
}
