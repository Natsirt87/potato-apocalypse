using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Rotation Controller")]
    [SerializeField] private float rotPGain = 1f;
    [SerializeField] private float rotDGain = 1f;
    [SerializeField] private float rotIGain = 1f;
    [SerializeField] private float rotIMax = 1f;
    [SerializeField] private float rotatePower = 1f;

    [Space(10)] 
    
    [Header("Thrust Controller")]
    [SerializeField] private float thrust = 5f;

    private Camera _camera;
    private Rigidbody2D _body;
    private Vector2 _bounds;

    private bool _derivativeInit = false;
    private float _valueLast = 0f;
    private float _integrationStored = 0f;

    void Start()
    {
        _camera = Camera.main;
        _body = GetComponent<Rigidbody2D>();
        _bounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        RotateToMouse();
        HandleThrust();

        Vector2 wrappedPos = _body.position;
        float wrapX = _bounds.x + 2f;
        float wrapY = _bounds.y + 1f;
        wrappedPos.x = (((wrappedPos.x + wrapX) % (wrapX * 2)) + (wrapX * 2)) % (wrapX * 2) - wrapX;
        wrappedPos.y = (((wrappedPos.y + wrapY) % (wrapY * 2)) + (wrapY * 2)) % (wrapY * 2) - wrapY;
        _body.position = wrappedPos;
    }
    
    // Rotate the player to look at the mouse position with physics magic 
    private void RotateToMouse()
    {
        float current = _body.rotation;
        Vector3 vectorToMouse = _camera.ScreenToWorldPoint(Input.mousePosition) - (Vector3)_body.position;
        float target = Quaternion.LookRotation(Vector3.forward, vectorToMouse).eulerAngles.z;
        float dt = Time.fixedDeltaTime;
        
        float error = AngleDifference(target, current);
        float p = rotPGain * error;

        float valueRateOfChange = AngleDifference(current, _valueLast);
        _valueLast = current;

        float d = 0f;
        if (_derivativeInit)
        {
            d = rotDGain * -valueRateOfChange;
        }
        else
        {
            _derivativeInit = true;
        }

        _integrationStored += (error * dt);
        _integrationStored = Mathf.Clamp(_integrationStored + (error * dt), -rotIMax, rotIMax);
        float i = rotIGain * _integrationStored;
        
        _body.AddTorque((p + i + d) * rotatePower, ForceMode2D.Force);;
    }

    private float AngleDifference(float a, float b)
    {
        float diff = a - b;
        while (diff < -180) diff += 360;
        while (diff > 180) diff -= 360;
        return diff;
    }

    private void HandleThrust()
    {
        Vector2 up = transform.up;
        Vector2 right = transform.right;
        
        
        
        _body.AddForce(thrust * Input.GetAxis("Vertical") * up, ForceMode2D.Force);
        _body.AddForce(thrust * Input.GetAxis("Horizontal") * right, ForceMode2D.Force);
    }
}
