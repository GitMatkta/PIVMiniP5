using UnityEngine;

public class LightRotation : MonoBehaviour
{
    public float rotationSpeed = 30f;
    private bool shouldRotate = false;
    private float rotatedAngle = 0f;

    void Update()
    {
        if (shouldRotate && rotatedAngle < 180f)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationStep, 0, 0);
            rotatedAngle += rotationStep;

            if (rotatedAngle >= 180f)
            {
                rotatedAngle = 180f;
                shouldRotate = false;
                EventManager.LightRotated(); // Trigger chandelier fall event
            }
        }
    }

    public void StartRotation()
    {
        shouldRotate = true; // Enable rotation when called by LightInteraction
    }
}
