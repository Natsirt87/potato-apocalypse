using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // display gameover screen
    public void Setup() {
        // to pause the game
        Time.timeScale = 0;

        gameObject.SetActive(true);
    }

    // Restart button
    public void RestartButton() {
        // to restart the game
        Time.timeScale = 1;
        SceneManager.LoadScene("Prototype1");
    }

    // MainMenu button
    public void MainMenuButton() {
        SceneManager.LoadScene("StartMenu");
    }
}
