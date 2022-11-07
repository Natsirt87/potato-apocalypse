using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// add rigid body
// add collider
public class ProjectileBehavior : MonoBehaviour
{

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
