using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;                   // starting health
    public TextMeshProUGUI healthText;       // drag TMP text here

    void Start()
    {
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;

        UpdateHealthUI();

        Debug.Log("Player health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Add death logic here (reload scene, game over, etc.)
        gameObject.SetActive(false);
    }
}

