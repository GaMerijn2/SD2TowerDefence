using UnityEngine;

public class FollowShaderWave : MonoBehaviour
{
    public Material waterMaterial; // Reference to the water shader material

    private float rippleSpeed;
    private float rippleDensity;
    private float waveHeight;

    private float originalHeight; // Store the original height of the object

    void Start()
    {
        // Retrieve values from the shader
        rippleSpeed = waterMaterial.GetFloat("_RippleSpeed");
        rippleDensity = waterMaterial.GetFloat("_RippleDensity");
        waveHeight = waterMaterial.GetFloat("_WaveHeight");

        // Store the object's initial height
        originalHeight = transform.position.y;
    }

    void Update()
    {
        // Get the object's current position
        Vector3 position = transform.position;

        // Time-based wave calculations from the shader
        float time = Time.time * rippleSpeed;
        float waveOffset = Mathf.Sin((position.x * rippleDensity) + time) +
                           Mathf.Cos((position.z * rippleDensity) + time);

        // Scale the wave offset by wave height
        waveOffset *= waveHeight /2;

        // Update the object's height based on the wave offset
        position.y = originalHeight + waveOffset;

        // Apply the new position
        transform.position = position;
    }
}
