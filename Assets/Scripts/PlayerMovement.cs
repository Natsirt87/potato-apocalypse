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

    private Camera _camera;
    private Rigidbody2D _body;
    
    void Start()
    {
        _camera = Camera.main;
        _body = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        RotateToMouse();
    }
    // Rotate the player to look at the mouse position with physics magic 
    private void RotateToMouse()
    {
        float current = _body.rotation;
        float dt = Time.fixedDeltaTime;
        
        // Get angle to mouse position
        Vector3 vectorToMouse = _camera.ScreenToWorldPoint(Input.mousePosition) - (Vector3)_body.position;
        float target = Quaternion.LookRotation(Vector3.forward, vectorToMouse).eulerAngles.z;

        float error = AngleDifference(target, current);

        float p = pGain * error;
        



        // bool shouldDecelerate;
        // bool shouldAccelerate;
        // if (turnAngle < 0)
        // {
        //     
        //     shouldDecelerate = angVel * stopRotateTime <= turnAngle;
        //     shouldAccelerate = angVel > -rotateSpeed;
        // }
        // else
        // {
        //     shouldDecelerate = _body.angularVelocity * stopRotateTime >= turnAngle;
        //     shouldAccelerate = angVel < rotateSpeed;
        // }
        //
        // // We're going to overshoot (we've reached the time when we should decelerate)
        // if (shouldDecelerate)
        // {
        //     Debug.Log("Deceleration time!");
        //     
        //     // Calculate angle needed to slow down by each frame in order to stop rotating in stopRotateTime
        //     //float decelForce = (-turnAngle / rotateDecelScale) * _body.inertia;
        //     
        //     // Apply torque to decelerate
        //     _body.AddTorque(decelForce, ForceMode2D.Force);
        // }
        // // It's time to accelerate
        // else if (Mathf.Abs(turnAngle) > 0.1f && shouldAccelerate)
        // {
        //     // Accelerate to rotate towards mouse
        //     Debug.Log("Acceleration time!");
        //
        //     // Apply torque to accelerate
        //     _body.AddTorque(turnAngle > 0 ? rotateAccelForce : -rotateAccelForce, ForceMode2D.Force);
        // }
    }

    private float AngleDifference(float a, float b)
    {
        return (a - b + 540) % 360 - 180;
    }
}
