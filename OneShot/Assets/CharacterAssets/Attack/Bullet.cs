using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Health enemy = collision.gameObject.GetComponent<Health>();
        if (enemy != null)
        {
            enemy.Damage(3);
        }
        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
    }
}
