using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MashedPotato : Potato
{
    public float movementForce = 4f;

    public Sprite sprite1;
    public Sprite sprite2;

    public float shockInterval = 3f;

    public ParticleSystem shockwaveEffect;
    public float shockwaveLength = .75f;

    private bool _canShock = false;
    private float _shockTimer = 0f;

    private PointEffector2D effector;

    public override void Start()
    {
        base.Start();

        if (Random.value > 0.5f)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else 
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;    
        }

        effector = GetComponent<PointEffector2D>();
    }

    void OnBecameVisible()
    {
        _canShock = true;
    }

    void FixedUpdate()
    {
        Vector2 vectorToPlanet = Vector2.zero - Body.position;
        Body.AddForce((vectorToPlanet / vectorToPlanet.magnitude) * movementForce, ForceMode2D.Force);
    }

    new void Update()
    {
        base.Update();
        if (_canShock)
        {
            if (_shockTimer >= shockInterval)
            {
                _shockTimer = 0;
                Shock();
            }
            else
            {
                _shockTimer += Time.deltaTime;

                if (_shockTimer >= shockwaveLength)
                {
                    effector.enabled = false;
                }
            }
        }
    }

    private void Shock()
    {
        shockwaveEffect.Play();
        Debug.Log("Shocking time");
        effector.enabled = true;
    }
}
