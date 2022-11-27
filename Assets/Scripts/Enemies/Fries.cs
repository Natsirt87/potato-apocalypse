using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fries : Potato
{
    public GameObject fry;
    public float movementForce = 4f;
    public float shootInterval = 1f;
    public float projectileForce = 5f;
    
    private bool _canShoot = false;
    public override void Start()
    {
        base.Start();
    }

    void OnBecameVisible()
    {
        _canShoot = true;
    }

    void FixedUpdate()
    {
        Vector2 vectorToPlanet = Vector2.zero - Body.position;
        Body.AddForce((vectorToPlanet / vectorToPlanet.magnitude) * movementForce, ForceMode2D.Force);

        if (_canShoot)
        {
            StartCoroutine(ShootFry());
        }
    }
    
    private IEnumerator ShootFry()
    {
        _canShoot = false;

        GameObject spawnedFry = Instantiate(fry);
        
        spawnedFry.transform.position = this.transform.position;
            
        Rigidbody2D fryRB = spawnedFry.GetComponent<Rigidbody2D>();

        fryRB.velocity = GetComponent<Rigidbody2D>().velocity;
        Vector3 force = spawnedFry.transform.right * projectileForce;
        fryRB.AddForce(force, ForceMode2D.Impulse);

        // wait for .4 seconds    
        yield return new WaitForSeconds(shootInterval);
        _canShoot = true;
    }
}
