using UnityEngine;

public class EnemyType2 : MonoBehaviour
{
    public float speed = 3f;          // Downward speed
    public float horizontalSpeed = 2f; // Left/right speed
    public float amplitude = 3f;       // Zigzag width

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Zigzag movement pattern
        float x = Mathf.Sin(Time.time * horizontalSpeed) * amplitude;
        float y = -speed * Time.deltaTime;
        transform.Translate(new Vector3(x, y, 0) * Time.deltaTime);

        // Destroy when off-screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
