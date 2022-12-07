using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    // For health bar
    public float health = 100f;
	public HealthBar healthBar;
    public float damageAnimLength = 1f;

    public float rotationSpeed = 1f;
    
    private float _damageAnimTime = 0f;
    private bool _justHit = false;

    private SpriteRenderer _sprite;

    void Start() {
        healthBar.SetMaxHealth(health);
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlanetRotate();
        if (health <= 0)
        {
            Debug.Log("Planet has died");
        }

        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.C))
        {
            ReloadScene();
        }

        if (_justHit)
        {
            _damageAnimTime += Time.deltaTime;

            if (_damageAnimTime <= damageAnimLength)
            {
                Color col = _sprite.color;
                if (_damageAnimTime < damageAnimLength/2)
                {
                    col.a = Mathf.Lerp(1, 0.6f, _damageAnimTime / damageAnimLength/2);
                }
                else
                {
                    col.a = Mathf.Lerp(0.6f, 1, (_damageAnimTime - (damageAnimLength/2)) / (damageAnimLength/2));
                }
                _sprite.color = col;
            }
            else 
            {
                _justHit = false;
                _damageAnimTime = 0;
            }
        }

    }

    public void Damage(float amount) 
    {
        health -= amount;
        healthBar.SetHealth(health);

        _justHit = true;
        _damageAnimTime = 0;

        if (health <= 0)
        {
            // to load game over scene when planet health == 0
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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