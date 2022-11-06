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
            manager.PotatoDestroyed(this);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Egg"))
        {
            health-=25;
            //Color fadeColor = GetComponent<SpriteRenderer>().color;
            //fadeColor.a = health * 0.01f;
            //GetComponent<SpriteRenderer>().color = fadeColor;

            if(health == 0)
            {
                Destroy(this.gameObject);
                // manager.spawnPlane();
                // manager.destroyedEnemyCount();
            }
        }
        // }
        // else if(collider.gameObject.CompareTag("Player"))
        // {
        //     manager.spawnPlane();
        //     Destroy(this.gameObject);
        //     manager.destroyedEnemyCount();
        // }
        // else if(!collider.gameObject.CompareTag("Enemy") && !collider.gameObject.CompareTag("WayPoint"))
        // {
        //     Destroy(this.gameObject);
        //     manager.spawnPlane();
        // }

    }
    
}
