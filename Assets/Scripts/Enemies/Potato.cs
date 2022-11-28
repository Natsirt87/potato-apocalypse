using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potato : MonoBehaviour
{
    [SerializeField] protected float health = 100f;
    [SerializeField] protected float planetDamage = 10f;
    public PotatoManager manager;
    public GameObject player;
    public Material flashMaterial;
    public float hitFlashTime = 0.1f;

    protected Rigidbody2D Body;

    private float _hitTime = 0;
    private bool _justHit = false;

    private SpriteRenderer _sprite;
    private Material _defaultMaterial;

    public virtual void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        
        _sprite = GetComponent<SpriteRenderer>();
        _defaultMaterial = _sprite.material;

        float scaleFactor = UnityEngine.Random.Range(0.9f, 1.15f);

        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * scaleFactor, scale.y * scaleFactor, 1);
        
        transform.Rotate(0f, 0f, UnityEngine.Random.Range(0f, 360f));
    }

    public void Update()
    {
        if (_justHit)
        {
            if (_hitTime < hitFlashTime)
            {
                _hitTime += Time.deltaTime;
                _sprite.material = flashMaterial;
            }
            else 
            {
                _justHit = false;

                _sprite.material = _defaultMaterial;
                _hitTime = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Planet"))
        {
            col.gameObject.GetComponent<Planet>().Damage(planetDamage);
            manager.EnemyDestroyed(this);
            Destroy(gameObject);
        }
    }

    public void damage(float amount)
    {
        health -= amount;

        _justHit = true;
        _hitTime = 0;

        _sprite.material = flashMaterial;

        if (health <= 0)
        {
            manager.EnemyDestroyed(this);
            Destroy(this.gameObject);
        }
    }
}
