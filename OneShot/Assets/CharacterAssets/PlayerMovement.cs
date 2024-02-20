using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float move;

    public float jump;

    public int groundCount; // Number of ground contacts
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        // Flip the character sprite if moving left
        if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip horizontally
        }
        else if (move > 0) // If moving right
        {
            transform.localScale = new Vector3(1, 1, 1); // Reset scale
        }

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && groundCount > 0) // Jump with W or Space, only if grounded
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            groundCount++;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            groundCount--;
        }
    }
}
