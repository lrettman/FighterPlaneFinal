using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 1; // damage to deal if shield inactive

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only respond to the player
        if (collision.CompareTag("Player"))
        {
            PlayerShield shield = collision.GetComponent<PlayerShield>();
            
            // If player has active shield, destroy enemy
            if (shield != null && shield.isShieldActive)
            {
                Destroy(gameObject);
                Debug.Log("Enemy destroyed by shield!");
                return; // exit so player doesn't take damage
            }

            // If no shield, deal damage to the player
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Player took damage!");
            }
        }
    }
}
