using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicerLaser : Projectile
{
    public GameObject explosion;

    public new void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Potato"))
        {
            collision.gameObject.GetComponent<Potato>().damage(damage);
            GameObject realExplosion = Instantiate(explosion);
            realExplosion.transform.position = transform.position;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Planet"))
        {
            Destroy(this.gameObject);
        }
    }
}