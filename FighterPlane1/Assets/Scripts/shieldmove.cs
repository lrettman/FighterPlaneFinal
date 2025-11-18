using UnityEngine;

public class ShieldMovement : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Optional: destroy if it goes offscreen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
