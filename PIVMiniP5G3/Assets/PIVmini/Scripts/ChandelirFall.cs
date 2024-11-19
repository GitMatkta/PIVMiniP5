using UnityEngine;

public class ChandelierFall : MonoBehaviour
{
    public float fallSpeed = 5f;
    public GameObject key; // Public reference for the key
    private Rigidbody rb;
    private bool shouldFall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        // Ensure the key is initially inactive
        if (key != null)
        {
            key.SetActive(false);
        }

        // Subscribe to the chandelier fall event
        EventManager.OnChandelierFall += StartFalling;
    }

    void OnDestroy()
    {
        EventManager.OnChandelierFall -= StartFalling;
    }

    private void StartFalling()
    {
        rb.useGravity = true;

        // Activate the key when the chandelier starts falling
        if (key != null)
        {
            key.SetActive(true);
            Debug.Log("Key activated when chandelier falls.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
        }
    }
}
