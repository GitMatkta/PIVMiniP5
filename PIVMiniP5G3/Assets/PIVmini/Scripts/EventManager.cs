using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnBookInteracted;
    public static event Action OnLightRotated;
    public static event Action OnChandelierFall; // event for chandelier fall

    public static bool IsBookInteracted { get; private set; } = false;

    public static void BookInteracted()
    {
        IsBookInteracted = true;
        OnBookInteracted?.Invoke();
    }

    public static void LightRotated()
    {
        OnLightRotated?.Invoke();
        OnChandelierFall?.Invoke(); // Trigger chandelier fall event after light rotation
    }
}
