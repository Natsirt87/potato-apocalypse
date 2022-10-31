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
}
