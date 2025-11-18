using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // First enemy type
    public GameObject enemyType2Prefab; // Second enemy type

    public float spawnInterval1 = 2f;   // First enemy spawn rate
    public float spawnInterval2 = 4f;   // Second enemy spawn rate

    public float spawnRangeX = 4f;      // Horizontal spawn range
    public float spawnY = 6f;           // Vertical spawn position

    private float timer1;
    private float timer2;

    void Update()
    {
        // Timer for enemy type 1
        timer1 += Time.deltaTime;
        if (timer1 >= spawnInterval1)
        {
            SpawnEnemy(enemyPrefab);
            timer1 = 0f;
        }

        // Timer for enemy type 2
        timer2 += Time.deltaTime;
        if (timer2 >= spawnInterval2)
        {
            SpawnEnemy(enemyType2Prefab);
            timer2 = 0f;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
