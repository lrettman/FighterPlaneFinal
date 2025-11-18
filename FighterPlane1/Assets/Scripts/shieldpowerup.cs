using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    [Header("Shield Settings")]
    public float shieldDuration = 5f; // How long the shield lasts

    [Header("Optional Audio")]
    public AudioSource audioSource;
    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player touched the power-up
        if (collision.CompareTag("Player"))
        {
            PlayerShield shield = collision.GetComponent<PlayerShield>();

            if (shield != null)
            {
                // Activate shield on the player
                shield.ActivateShield(shieldDuration);
            }

            // Play pickup sound
            if (audioSource != null && pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

            // Destroy the power-up object
            Destroy(gameObject);
        }
    }
}
