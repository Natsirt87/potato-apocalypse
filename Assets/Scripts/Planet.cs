using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    // For health bar
    public float maxHealth = 100f;
	public float currHealth;
	public HealthBar healthBar;

    // For Game Over Screen
    public GameOverScreen gameover;

    public float rotationSpeed = 1f;

    void Start() {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        PlanetRotate();
        if (currHealth <= 0)
        {
            Debug.Log("Planet has died");
        }

        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.C))
        {
            ReloadScene();
        }
    }

    public void Damage(float amount) 
    {
        currHealth -= amount;
        healthBar.SetHealth(currHealth);

        if (currHealth <= 0)
        {
            gameover.Setup();
        }
    }

    private void PlanetRotate()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * 360 * rotationSpeed * 0.01f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}