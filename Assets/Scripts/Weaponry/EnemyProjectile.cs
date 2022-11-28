using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// add rigid body
// add collider
public class EnemyProjectile : MonoBehaviour
{

    void OnBecameInvisible() // destroy the projectile on collision with enemy
    {
        Destroy(this.gameObject);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Planet"))
        {
            Destroy(this.gameObject);
        }
    }
}
