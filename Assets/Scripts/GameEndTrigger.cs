using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndTrigger : MonoBehaviour
{
    public GameObject endMenuCanvas;  // Reference to the Canvas component
    public Button endButton; // Reference to the End Game button
    public Button backButton; // Reference to the Cancel button

    private MonoBehaviour fpsController;

    private void Start()
    {
        Time.timeScale = 1f;
        fpsController = FindObjectOfType<FirstPersonController>();

        if (endMenuCanvas == null)
        {
            endMenuCanvas = GameObject.Find("EndMenu");
            if (endMenuCanvas == null)
            {
                Debug.LogError("EndMenu canvas not found! Make sure it exists and is named 'EndMenu'.");
                return;
            }
        }

        // Find buttons within the EndMenu
        if (endButton == null)
        {
            endButton = endMenuCanvas.transform.Find("EndButton").GetComponent<Button>();
        }

        if (endButton == null)
        {
            endButton = endMenuCanvas.transform.Find("BackButton").GetComponent<Button>();
        }

        // Add listeners to buttons
        if (backButton != null)
        {
            backButton.onClick.AddListener(Cancel);
        }
        else
        {
            Debug.LogWarning("Resume button not found!");
        }

        if (endButton != null)
        {
            endButton.onClick.AddListener(EndGame);
        }
        else
        {
            Debug.LogWarning("Quit button not found!");
        }

        // Ensure the pause menu is not visible at start
        endMenuCanvas.SetActive(false);
    }


    public void ShowPopup(Collider other)
    {
        if (other.CompareTag("Player") && endMenuCanvas != null)
        {
            // Show the pop-up panel
            endMenuCanvas.SetActive(true);
            // Show and unlock the cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (fpsController != null)
            {
                fpsController.enabled = false;
            }
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
        if (endMenuCanvas != null)
        {
            endMenuCanvas.SetActive(false);
            // Hide and lock the cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (fpsController != null)
            {
                fpsController.enabled = true;
            }
        }
    }
}
