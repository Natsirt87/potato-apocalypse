using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehavior : MonoBehaviour
{
    public float speed = 5f;
    public float brakeSpeed = 2f;
    public float rotateSpeed = 3f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        // Turning
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,0,rotateSpeed);
            //rb2d.AddForce(-transform.right * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0,0,-1 * rotateSpeed);
            //rb2d.AddForce(transform.right * rotateSpeed);
        }

        // Change Speed
        if (Input.GetKey(KeyCode.W)) {
            rb2d.AddForce(transform.up * speed);
        } else if (Input.GetKey(KeyCode.S)) {
            rb2d.AddForce(-rb2d.velocity * brakeSpeed);
        }
    }
}
