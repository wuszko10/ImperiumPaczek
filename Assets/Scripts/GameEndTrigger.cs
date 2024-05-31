using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndTrigger : MonoBehaviour
{
    public Canvas popUpCanvas;  // Reference to the Canvas component
    public Button endGameButton; // Reference to the End Game button
    public Button cancelButton; // Reference to the Cancel button

    private void Start()
    {
        // Find the Canvas and Buttons if they are not assigned in the Inspector
        if (popUpCanvas == null)
        {
            popUpCanvas = GameObject.Find("PopUpCanvas").GetComponent<Canvas>();
        }

        if (endGameButton == null)
        {
            endGameButton = popUpCanvas.transform.Find("EndGameButton").GetComponent<Button>();
        }

        if (cancelButton == null)
        {
            cancelButton = popUpCanvas.transform.Find("CancelButton").GetComponent<Button>();
        }

        // Ensure the pop-up is not visible at the start
        if (popUpCanvas != null)
        {
            popUpCanvas.gameObject.SetActive(false);
        }

        // Add listeners to the buttons
        if (endGameButton != null)
        {
            endGameButton.onClick.AddListener(EndGame);
        }

        if (cancelButton != null)
        {
            cancelButton.onClick.AddListener(Cancel);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && popUpCanvas != null)
        {
            // Show the pop-up panel
            popUpCanvas.gameObject.SetActive(true);
            // Show and unlock the cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void EndGame()
    {
        // End the game
        Application.Quit();

        // If running in the editor, stop playing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void Cancel()
    {
        // Hide the pop-up panel
        if (popUpCanvas != null)
        {
            popUpCanvas.gameObject.SetActive(false);
            // Hide and lock the cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
