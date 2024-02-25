using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private SpriteRenderer playerSpriteRenderer; // Reference to the player's sprite renderer

    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        playerSpriteRenderer = GetComponent<SpriteRenderer>(); // Get the player's sprite renderer component
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                ShowPlayerSprite(); // Show the player's sprite when the attack is finished
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        HidePlayerSprite(); // Hide the player's sprite when attacking
    }

    private void HidePlayerSprite()
    {
        playerSpriteRenderer.enabled = false; // Hide the player's sprite
    }

    private void ShowPlayerSprite()
    {
        playerSpriteRenderer.enabled = true; // Show the player's sprite
    }
}
