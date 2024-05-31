using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleVisibility : MonoBehaviour
{
    // Przypisz obiekt w inspektorze Unity
    public GameObject targetObject;
    public TMP_Text infoText;

    void Start()
    {
        // Na pocz¹tku ukryj obiekt
        targetObject.SetActive(false);
    }

    // Funkcja do pokazania obiektu
    public void ShowObject(string message)
    {
        infoText.text = message;
        targetObject.SetActive(true);
        StartCoroutine(HideAfterDelay(15f)); // Uruchom coroutine do ukrycia obiektu po 10 sekundach
    }

    // Coroutine do ukrycia obiektu po okreœlonym czasie
    IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        targetObject.SetActive(false);
    }
}
