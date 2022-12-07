using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// add rigid body
// add collider
public class Projectile : MonoBehaviour
{
    public float damage = 25f;

    protected Rigidbody2D body;

    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void OnBecameInvisible() // destroy the projectile on collision with enemy
    {
        Destroy(this.gameObject);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Potato"))
        {
            collision.gameObject.GetComponent<Potato>().damage(damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Planet"))
        {
            Destroy(this.gameObject);
        }
    }

    public void Update()
    {
        transform.right = body.velocity.normalized;
    }
}
