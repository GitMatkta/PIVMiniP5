using UnityEngine;
using System.Collections;

public class BookInteraction : MonoBehaviour
{
    public GameObject bookCover;
    public GameObject textDisplay;
    private bool isOpen = false;

    void Start()
    {
        if (textDisplay != null)
        {
            textDisplay.SetActive(false);
        }
    }

    public void OnBookInteract()
    {
        if (!isOpen)
        {
            StartCoroutine(OpenBook());
            if (textDisplay != null) textDisplay.SetActive(true);
            EventManager.BookInteracted(); // Trigger the event here
        }
        else
        {
            StartCoroutine(CloseBook());
            if (textDisplay != null) textDisplay.SetActive(false);
        }
        isOpen = !isOpen;
    }

    private IEnumerator OpenBook()
    {
        float duration = 0.5f;
        float time = 0;
        Quaternion closedRotation = Quaternion.Euler(0, 0, 0);
        Quaternion openRotation = Quaternion.Euler(-90, 0, 0);

        while (time < duration)
        {
            bookCover.transform.localRotation = Quaternion.Lerp(closedRotation, openRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        bookCover.transform.localRotation = openRotation;
    }

    private IEnumerator CloseBook()
    {
        float duration = 0.5f;
        float time = 0;
        Quaternion openRotation = bookCover.transform.localRotation;
        Quaternion closedRotation = Quaternion.Euler(0, 0, 0);

        while (time < duration)
        {
            bookCover.transform.localRotation = Quaternion.Lerp(openRotation, closedRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        bookCover.transform.localRotation = closedRotation;
    }
}
