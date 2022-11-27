using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    public float health = 100f;
    public float rotationSpeed = 1f;
    
    [SerializeField] private TextMeshProUGUI healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Planet Health: " + Mathf.Clamp(health, 0, 1000);

        PlanetRotate();
        if (health <= 0)
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
        health -= amount;
        if (health <= 0)
        {
            ReloadScene();
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
