using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PausedMenuCanvas;
    public Button cancelButton;
    public Button endGameButton;

    private MonoBehaviour fpsController;

    void Start()
    {
        Time.timeScale = 1f;
        fpsController = FindObjectOfType<FirstPersonController>();

        if (PausedMenuCanvas == null)
        {
            PausedMenuCanvas = GameObject.Find("PauseMenu");
            if (PausedMenuCanvas == null)
            {
                Debug.LogError("PauseMenu canvas not found! Make sure it exists and is named 'PauseMenu'.");
                return;
            }
        }

        // Find buttons within the PauseMenuCanvas
        if (cancelButton == null)
        {
            cancelButton = PausedMenuCanvas.transform.Find("Resume").GetComponent<Button>();
        }

        if (endGameButton == null)
        {
            endGameButton = PausedMenuCanvas.transform.Find("Quit").GetComponent<Button>();
        }

        // Add listeners to buttons
        if (cancelButton != null)
        {
            cancelButton.onClick.AddListener(Play);
        }
        else
        {
            Debug.LogWarning("Resume button not found!");
        }

        if (endGameButton != null)
        {
            endGameButton.onClick.AddListener(MainMenuButton);
        }
        else
        {
            Debug.LogWarning("Quit button not found!");
        }

        // Ensure the pause menu is not visible at start
        PausedMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        PausedMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        if (fpsController != null)
        {
            fpsController.enabled = false;
        }
    }

    public void Play()
    {
        PausedMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (fpsController != null)
        {
            fpsController.enabled = true;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
