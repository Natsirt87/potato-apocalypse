using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float health = 100f;
    public float rotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlanetRotate();
    }

    private void PlanetRotate()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * 360 * rotationSpeed * 0.01f);
    }
}
