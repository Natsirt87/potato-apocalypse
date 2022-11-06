using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// add rigid body
// add collider
public class EggBehavior : MonoBehaviour
{
    public float speed = 40f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.smoothDeltaTime;

        // Spawned eggs expires when either of the following condition is true
        // It reaches the bounds of the world
        // It collides with an enemy

    }

    void OnBecameInvisible()//destroy the egg on collision with enemy
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Potato"))
        {
            Destroy(this.gameObject);
        }
    }

}
