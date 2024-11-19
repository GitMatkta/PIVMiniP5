using UnityEngine;
using System.Collections;

public class LowerBookcase : MonoBehaviour
{
    public float lowerOffset = 1f; // Extra distance to ensure it moves fully underground
    public float lowerSpeed = 2f; // Speed at which the bookcase lowers
    private bool isLowered = false; // Track if the bookcase has been lowered

    public Renderer bookcaseRenderer; // Assign this in the Inspector

    // This method will be called by the button's XR interaction event
    public void Lower()
    {
        if (isLowered) return; // Avoid lowering more than once

        if (bookcaseRenderer == null)
        {
            Debug.LogError("Bookcase Renderer is not assigned.");
            return;
        }

        float bookcaseHeight = bookcaseRenderer.bounds.size.y;
        float lowerAmount = bookcaseHeight + lowerOffset;
        StartCoroutine(LowerSmoothly(lowerAmount));
        isLowered = true;
    }

    private IEnumerator LowerSmoothly(float lowerAmount)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition - new Vector3(0, lowerAmount, 0);

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, lowerSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure it reaches the exact target position
        transform.position = targetPosition;
    }
}
