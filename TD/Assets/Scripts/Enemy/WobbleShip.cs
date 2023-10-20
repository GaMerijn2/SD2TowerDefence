using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleShip : MonoBehaviour
{
    public float wobbleAngle = 15.0f; // The maximum angle the ship should wobble
    public float wobbleSpeed = 10f;  // The speed of the wobbling effect

    private float currentAngle = 0.0f;
    private bool wobblingRight = true;

    private void Update()
    {
        // Rotate the ship back and forth
        if (wobblingRight)
        {
            currentAngle += wobbleSpeed * Time.deltaTime;
            if (currentAngle >= wobbleAngle)
            {
                currentAngle = wobbleAngle;
                wobblingRight = false;
            }
        }
        else
        {
            currentAngle -= wobbleSpeed * Time.deltaTime;
            if (currentAngle <= -wobbleAngle)
            {
                currentAngle = -wobbleAngle;
                wobblingRight = true;
            }
        }

        // Apply the rotation to the ship's Transform
        transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, currentAngle);
    }
}

