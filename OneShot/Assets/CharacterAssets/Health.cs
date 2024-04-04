using System.Collections;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public int health;
    public int MAX_HEALTH;
    public static Action OnPlayerDeath;
    public static Action OnEnemyHealth;
    public HealthBarScript healthBar;
    //public Weapon weapon;


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
            healthBar.SetMaxHealth(MAX_HEALTH);
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

        this.health -= amount;
        StartCoroutine(VisualIndicator(Color.red));

        if (gameObject.CompareTag("Player"))
        {
            healthBar.SetBarHealth(health);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            if (this.CompareTag("Player"))
            {
                Time.timeScale = 0;
                OnPlayerDeath?.Invoke();
            }
            else
            {
                OnEnemyHealth?.Invoke();
            }
            //weapon.ammoCount++;
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
