using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float vertical;
    private float LadderSpeed = 8f;
    private bool isLadder;
    private bool isClimbing;


    public float speed;
    private float move;
    private bool m_FacingRight = true;

    public float jump;

    public int groundCount; // Number of ground contacts

    [SerializeField] private Rigidbody2D rb;

    public Transform respawnPoint; // Respawn point

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
        if (move < 0 && m_FacingRight == true)
        {
           Flip();
           // transform.localScale = new Vector3(-1, 1, 1); // Flip horizontally
        }
        else if (move > 0 && m_FacingRight == false) 
         // If moving right
        {
            Flip();
           // transform.localScale = new Vector3(1, 1, 1); // Reset scale
        }

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && groundCount > 0) // Jump with W or Space, only if grounded
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        // Check if player falls below deathYLevel
        if (transform.position.y < -10f)
        {
            Respawn();
        }

        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * LadderSpeed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }


    private void Flip(){
        m_FacingRight = !m_FacingRight;

        transform.Rotate (0f, 180, 0f);
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

    // Respawn the player at the respawn point
    private void Respawn()
    {
        transform.position = respawnPoint.position;
        rb.velocity = Vector2.zero; // Reset velocity
    }
}
