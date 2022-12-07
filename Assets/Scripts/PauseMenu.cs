using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // whether or not our game is currently paused
    public static bool IsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        // will be on Planet update
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // esc has been pressed & game has been paused
            if (IsPaused) {
                Resume();
            }
            // press esc while the game is NOT paused
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        // bring resume menu
        pauseMenuUI.SetActive(false);

        // set time back to normal
        Time.timeScale = 1f;

        // change ISPAUSED to false
        IsPaused = false;
    }

    public void Pause() {
        // bring pause menu
        pauseMenuUI.SetActive(true);

        // freeze time in a game
        Time.timeScale = 0f;

        // change ISPAUSED to true
        IsPaused = true;
    }

    public void LoadMenu() {
        // set time back to normal
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
