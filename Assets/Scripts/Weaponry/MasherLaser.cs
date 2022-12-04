using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasherLaser : Projectile
{
    public float lifetime = 2f;
    public float fadeOffset = 0.5f;

    private float _startSpeed;
    private float _lifeTimer = 0f;
    private SpriteRenderer _renderer;

    new void Start()
    {
        base.Start();

        _startSpeed = body.velocity.magnitude;
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        _lifeTimer += Time.deltaTime;
        if (_lifeTimer >= lifetime)
        {
            Destroy(this.gameObject);
        }

        Color col = _renderer.color;
        col.a = Mathf.Clamp((lifetime - _lifeTimer) / (lifetime - fadeOffset), 0f, 1f);
        _renderer.color = col;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Potato"))
        {
            collision.gameObject.GetComponent<Potato>().damage(damage * (body.velocity.magnitude / _startSpeed));
            Destroy(this.gameObject);
        }
    }
}
