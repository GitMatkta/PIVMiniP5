using UnityEngine;

public class ScalePulse : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseAmount = 1.1f;
    private Vector3 originalScale;
    private bool shouldPulse = false;

    void Start()
    {
        originalScale = transform.localScale;
        EventManager.OnBookInteracted += StartPulsing; // Subscribe to the event
    }

    void OnDestroy()
    {
        EventManager.OnBookInteracted -= StartPulsing; // Unsubscribe from the event
    }

    void Update()
    {
        if (shouldPulse)
        {
            float scale = Mathf.Lerp(1f, pulseAmount, Mathf.PingPong(Time.time * pulseSpeed, 1));
            transform.localScale = originalScale * scale;
        }
    }

    private void StartPulsing()
    {
        shouldPulse = true; // Enable pulsing when the event is triggered
    }
}
