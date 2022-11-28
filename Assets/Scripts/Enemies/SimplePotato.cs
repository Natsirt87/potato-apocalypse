using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimplePotato : Potato
{
    public float movementForce = 4f;

    public Sprite sprite1;
    public Sprite sprite2;

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
    }

    void FixedUpdate()
    {
        Vector2 vectorToPlanet = Vector2.zero - Body.position;
        Body.AddForce((vectorToPlanet / vectorToPlanet.magnitude) * movementForce, ForceMode2D.Force);
    }
}
