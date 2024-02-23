using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private int MAX_HEALTH;

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


    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        health -= amount;

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
    }
}
