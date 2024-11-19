using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorScript : MonoBehaviour
{
    public Transform pivotPoint;
    public float rotationSpeed = 30f;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor keySocket; // Reference to the socket
    private bool doorOpening = false;
    private float rotatedAngle = 0f;
    private bool puzzleSolved = false; // Tracks if the puzzle is solved

    void Start()
    {
        Debug.Log("DoorScript initialized. Waiting for key insertion and puzzle completion.");

        // Subscribe to the Select Entered event
        keySocket.selectEntered.AddListener(OnKeyInserted);
    }

    void Update()
    {
        if (doorOpening && rotatedAngle < 90f)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            pivotPoint.Rotate(0, rotationStep, 0);
            rotatedAngle += rotationStep;
            Debug.Log("Rotating door. Current angle: " + rotatedAngle);
        }
    }

    public void SetPuzzleSolved(bool isSolved)
    {
        puzzleSolved = isSolved;
        Debug.Log($"Puzzle solved status updated: {puzzleSolved}");
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        Debug.Log("Key has been inserted into the socket.");

        // Only unlock the door if the puzzle is also solved
        if (puzzleSolved)
        {
            Debug.Log("Both key and puzzle conditions met. Door will open.");
            UnlockDoor();
        }
        else
        {
            Debug.Log("Puzzle not solved. Door will remain locked.");
        }
    }

    public void UnlockDoor()
    {
        if (!doorOpening)
        {
            doorOpening = true;
            Debug.Log("UnlockDoor called. Door is now opening!");
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid errors when this object is destroyed
        keySocket.selectEntered.RemoveListener(OnKeyInserted);
    }
}
