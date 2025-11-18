using UnityEngine;
using TMPro;

public class PlayerShield : MonoBehaviour
{
    [Header("Shield Settings")]
    public bool isShieldActive = false;
    private float shieldTimer = 0f;

    [Header("Audio")]
    public AudioSource audioSource;      // assign AudioSource on player
    public AudioClip shieldPickupSound;  // plays when shield is collected
    public AudioClip shieldOnSound;      // plays when shield activates
    public AudioClip shieldOffSound;     // plays when shield expires

    [Header("Visuals")]
    public GameObject shieldVisual;      // optional visual indicator

    [Header("UI")]
    public TextMeshProUGUI shieldText;   // optional countdown text

    void Update()
    {
        if (isShieldActive)
        {
            shieldTimer -= Time.deltaTime;

            if (shieldText != null)
                shieldText.text = "Shield: " + Mathf.Ceil(shieldTimer);

            if (shieldTimer <= 0f)
                DeactivateShield();
        }
    }

    // Call this when the player picks up a shield
    public void ActivateShield(float duration)
    {
        isShieldActive = true;
        shieldTimer = duration;

        if (shieldText != null)
            shieldText.gameObject.SetActive(true);

        if (shieldVisual != null)
            shieldVisual.SetActive(true);

        // Play pickup sound immediately
        if (shieldPickupSound != null)
            AudioSource.PlayClipAtPoint(shieldPickupSound, transform.position);

        // Optional: play shield-on sound via AudioSource
        if (audioSource != null && shieldOnSound != null)
            audioSource.PlayOneShot(shieldOnSound);
    }

    private void DeactivateShield()
    {
        isShieldActive = false;

        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        if (shieldText != null)
            shieldText.gameObject.SetActive(false);

        if (audioSource != null && shieldOffSound != null)
            audioSource.PlayOneShot(shieldOffSound);
    }

    // Call this from EnemyDamage to destroy enemy if shield is active
    public bool TryDestroyEnemy(GameObject enemy)
    {
        if (isShieldActive)
        {
            Destroy(enemy);
            return true;
        }
        return false;
    }
}
