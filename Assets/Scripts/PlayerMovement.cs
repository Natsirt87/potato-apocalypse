using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float pGain = 1f;
    public float dGain = 1f;
    public float iGain = 1f;
    public float iSaturation = 1f;
    public float rotatePower = 1f;

    private Camera _camera;
    private Rigidbody2D _body;

    private bool _derivativeInit = false;
    private float _valueLast = 0f;
    private float _integrationStored = 0f;

    void Start()
    {
        _camera = Camera.main;
        _body = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        float currentRotation = _body.rotation;
        Vector3 vectorToMouse = _camera.ScreenToWorldPoint(Input.mousePosition) - (Vector3)_body.position;
        float targetRotation = Quaternion.LookRotation(Vector3.forward, vectorToMouse).eulerAngles.z;
        float dt = Time.fixedDeltaTime;
        
        _body.AddTorque(PidRotation(currentRotation, targetRotation, dt ) * rotatePower, ForceMode2D.Force);
    }
    
    // Rotate the player to look at the mouse position with physics magic 
    private float PidRotation(float current, float target, float dt)
    {
        float error = AngleDifference(target, current);
        float p = pGain * error;

        float valueRateOfChange = AngleDifference(current, _valueLast);
        _valueLast = current;

        float d = 0f;
        if (_derivativeInit)
        {

            d = dGain * -valueRateOfChange;
        }
        else
        {
            _derivativeInit = true;
        }

        _integrationStored += (error * dt);
        _integrationStored = Mathf.Clamp(_integrationStored + (error * dt), -iSaturation, iSaturation);
        float i = iGain * _integrationStored;

        return p + i + d;
    }

    private float AngleDifference(float a, float b)
    {
        return (a - b + 540) % 360 - 180;
    }
}
