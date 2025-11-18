using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;        // assign your shield prefab
    public float spawnInterval = 5f;       // seconds between spawns

    public float minX = -7f;               // left/right bounds for random spawn
    public float maxX = 7f;
    public float spawnY = 6f;              // top of screen
    public float fallSpeed = 3f;           // how fast shield falls

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnShield();
            timer = 0f;
        }
    }

    void SpawnShield()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);

        GameObject spawnedShield = Instantiate(shieldPrefab, spawnPos, Quaternion.identity);
        spawnedShield.name = "ShieldPickup";

        // Add simple downward movement
        ShieldMovement movement = spawnedShield.GetComponent<ShieldMovement>();
        if (movement == null)
        {
            movement = spawnedShield.AddComponent<ShieldMovement>();
        }
        movement.fallSpeed = fallSpeed;

        Debug.Log("Shield spawned at X=" + randomX);
    }
}

