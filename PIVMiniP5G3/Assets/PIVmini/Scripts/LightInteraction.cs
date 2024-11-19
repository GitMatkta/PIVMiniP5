using UnityEngine;

public class LightInteraction : MonoBehaviour
{
    private bool isInteracted = false;

    public void TriggerLightInteraction()
    {
        if (!isInteracted && EventManager.IsBookInteracted) // Check if book interaction happened
        {
            isInteracted = true;
            EventManager.BookInteracted(); // Trigger the pulsing effect
            StartRotation(); // Start rotation after interaction
        }
    }

    private void StartRotation()
    {
        LightRotation rotationScript = GetComponent<LightRotation>();
        if (rotationScript != null)
        {
            rotationScript.StartRotation(); // Call the StartRotation method in LightRotation
        }
    }
}
