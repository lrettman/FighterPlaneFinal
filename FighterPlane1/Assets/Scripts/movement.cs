using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    private float screenHalfWidth;
    private float minY;
    private float maxY;

    void Start()
    {
        Camera cam = Camera.main;

        float halfPlayerWidth = transform.localScale.x / 2f;
        float halfPlayerHeight = transform.localScale.y / 2f;

        // Calculate visible bounds in world space based on camera position
        float orthoHeight = cam.orthographicSize;
        float orthoWidth = orthoHeight * cam.aspect;

        float screenTop = cam.transform.position.y + orthoHeight;
        float screenBottom = cam.transform.position.y - orthoHeight;
        float screenMiddle = (screenTop + screenBottom) / 2f;

        // Horizontal wrap-around width
        screenHalfWidth = orthoWidth + halfPlayerWidth;

        // Define vertical movement limits for bottom half of the screen
        minY = screenBottom + halfPlayerHeight;  // Stop right above bottom edge
        maxY = screenMiddle - halfPlayerHeight;  // Stop at the middle
    }

    void Update()
    {
        // Get input
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Move player
        Vector3 move = new Vector3(inputX, inputY, 0f) * speed * Time.deltaTime;
        transform.position += move;

        // Clamp vertical movement
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Horizontal wrap-around
        if (pos.x < -screenHalfWidth)
            pos.x = screenHalfWidth;
        else if (pos.x > screenHalfWidth)
            pos.x = -screenHalfWidth;

        transform.position = pos;
    }
}
