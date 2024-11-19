using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public bool isPressed = false; // Public for PuzzleManager access
    private Renderer buttonRenderer;
    public Color defaultColor = Color.white;
    public Color pressedColor = Color.red;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        UpdateButtonColor();
    }

    public void OnButtonPress()
    {
        isPressed = !isPressed; // Toggle the button's state
        UpdateButtonColor();

        Debug.Log($"Button {gameObject.name} state: {isPressed}");
        
        // Notify PuzzleManager
        PuzzleManager.Instance?.CheckPuzzleState();
    }

    private void UpdateButtonColor()
    {
        // Update the button's color
        if (buttonRenderer != null)
        {
            buttonRenderer.material.SetColor("_BaseColor", isPressed ? pressedColor : defaultColor);
        }
    }
}
