using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potato : MonoBehaviour
{
    [SerializeField] protected float health = 100f;
    public PotatoManager manager;

    protected Rigidbody2D Body;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GameObject().CompareTag("Planet"))
        {
            col.GameObject().GetComponent<Planet>().Damage(10);
            manager.EnemyDestroyed(this);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Egg"))
        {
            health -= 25;

            if (health == 0)
            {
                manager.EnemyDestroyed(this);
                Destroy(this.gameObject);
            }
        }
    }
    
}
