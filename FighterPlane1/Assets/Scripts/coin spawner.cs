using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;          // assign your coin prefab
    public float spawnInterval = 3f;       // time between coin spawns

    // Spawn area 
    public float minX = -7f;
    public float maxX = 7f;
    public float minY = -4f;  // bottom half of screen
    public float maxY = 0f;

    public float checkRadius = 0.5f;       // distance to check for enemies
    public LayerMask enemyLayer;           // assign your enemies to this layer

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    void SpawnCoin()
    {
        Vector2 spawnPos;
        bool spotFree = false;
        int attempts = 0;

        // Try up to 20 times to find a free spot
        do
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            spawnPos = new Vector2(x, y);

            // Check for enemies
            spotFree = Physics2D.OverlapCircle(spawnPos, checkRadius, enemyLayer) == null;

            attempts++;
        } while (!spotFree && attempts < 20);

        if (spotFree)
        {
            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Vector3.zero, checkRadius);
    }
}


