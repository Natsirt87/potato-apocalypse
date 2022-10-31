using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimplePotato : Potato
{
    public float movementForce = 4f;

    void FixedUpdate()
    {
        Vector2 vectorToPlanet = Vector2.zero - Body.position;
        Body.AddForce((vectorToPlanet / vectorToPlanet.magnitude) * movementForce, ForceMode2D.Force);
    }
}
