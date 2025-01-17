using UnityEngine;

public class FollowWave : MonoBehaviour
{
    public Material waterMaterial; // Reference to your water material
    public float waveSpeed = 1f;  // Match speed from shader
    public float waveHeight = 1f; // Match height from shader
    public float waveFrequency = 1f; // Match frequency from shader

    private float originalHeight; // To store the object's initial height

    void Start()
    {
        // Store the object's original height at the start
        originalHeight = transform.position.y;
    }

    void Update()
    {
        // Get the object's position
        Vector3 position = transform.position;

        // Calculate wave offset
        float time = Time.time * waveSpeed;
        float waveOffset = Mathf.Sin((position.x + time) * waveFrequency) * waveHeight +
                           Mathf.Cos((position.z + time) * waveFrequency) * waveHeight;

        // Apply the wave offset while maintaining the original height
        position.y = originalHeight + waveOffset;
        transform.position = position;
    }
}