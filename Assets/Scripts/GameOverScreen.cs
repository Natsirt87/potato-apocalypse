using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // // display gameover screen
    // public void Setup() {
    //     // to load game over scene when planet health == 0
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    //     //gameObject.SetActive(true);
    // }

    // Restart button
    public void RestartButton() {
        SceneManager.LoadScene("Prototype1");
    }

    // MainMenu button
    public void MainMenuButton() {
        SceneManager.LoadScene("StartMenu");
    }
}