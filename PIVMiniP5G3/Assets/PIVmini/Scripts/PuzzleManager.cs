using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance; // Singleton for global access
    public ButtonPress[,] buttons = new ButtonPress[3, 3]; // Reference to the 3x3 matrix of buttons
    public DoorScript doorScript; // Reference to the DoorScript for unlocking the door
    private bool rightmostPressed = false; // Tracks if the rightmost condition is met

    private void Awake()
    {
        Instance = this; // Assign singleton instance
    }

    void Start()
    {
        // Automatically find all buttons in the 3x3 grid
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                string buttonName = $"Button_{i}_{j}";
                GameObject buttonObject = transform.Find(buttonName).gameObject;
                buttons[i, j] = buttonObject.GetComponent<ButtonPress>();
                Debug.Log($"Button {buttonName} registered in PuzzleManager.");
            }
        }
    }

    public void CheckPuzzleState()
    {
        // Check if the rightmost three cubes (2,0; 2,1; 2,2) are pressed
        bool rightmostCondition = buttons[2, 0].isPressed && buttons[2, 1].isPressed && buttons[2, 2].isPressed;

        if (rightmostCondition)
        {
            Debug.Log("Rightmost buttons are pressed! First step of the puzzle solved.");
            rightmostPressed = true;

            // Notify DoorScript that the puzzle is solved
            if (doorScript != null)
            {
                doorScript.SetPuzzleSolved(true);
            }
        }
        else
        {
            Debug.Log("Rightmost buttons are not all pressed yet.");
            rightmostPressed = false; // Reset the state if not all buttons are pressed
            if (doorScript != null)
            {
                doorScript.SetPuzzleSolved(false);
            }
        }
    }
}
