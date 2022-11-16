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

    public virtual void Start()
    {
        Body = GetComponent<Rigidbody2D>();

        float scaleFactor = UnityEngine.Random.Range(0.8f, 1.2f);

        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * scaleFactor, scale.y * scaleFactor, 1);
        
        transform.Rotate(0f, 0f, UnityEngine.Random.Range(0f, 360f));
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

    public void damage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            manager.EnemyDestroyed(this);
            Destroy(this.gameObject);
        }
    }
}
