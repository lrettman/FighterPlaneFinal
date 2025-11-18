using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    public float shieldDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerShield playerShield = other.GetComponent<PlayerShield>();
        if (playerShield != null)
        {
            // Activate shield on player
            playerShield.ActivateShield(shieldDuration);

            // Destroy the pickup
            Destroy(gameObject);
            Debug.Log("Shield picked up!");
        }
    }
}
