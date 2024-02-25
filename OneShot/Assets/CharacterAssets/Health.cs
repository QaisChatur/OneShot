using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private int MAX_HEALTH;
    public Weapon weapon;


    private void Start()
    {
        // Initialization of health and maxHealth values
        if (gameObject.CompareTag("EnemyType1")) // Assuming you have tags to differentiate between enemy types
        {
            health = 3; // Initial health for Enemy Type 1
            MAX_HEALTH = 3;
        }
        else if (gameObject.CompareTag("EnemyType2"))
        {
            health = 4; // Initial health for Enemy Type 2
            MAX_HEALTH = 4;
        }
        else if (gameObject.CompareTag("Player"))
        {
            health = 3; // Default to 3 health if the enemy type is the Player
            MAX_HEALTH = 3;
        }
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    private IEnumerator VisualIndicator(Color color)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
            float elapsedTime = 0f;
            float flashDuration = 0.15f;

            while (elapsedTime < flashDuration && gameObject != null)
            {
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }

            if (gameObject != null)
            {
                spriteRenderer.color = Color.white; // Reset color
            }
        }
    }



    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;
        StartCoroutine(VisualIndicator(Color.red));

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;
        StartCoroutine(VisualIndicator(Color.green));

        if (wouldBeOverMaxHealth)
        {
            health = MAX_HEALTH;
        }
        else
        {
            health += amount;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        weapon.ammoCount++;
    }
}
