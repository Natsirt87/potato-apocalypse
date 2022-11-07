using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private bool shoot = true;
    public GameObject prefab; 
    public float projectileForce = 10f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            if(shoot)
            {
                StartCoroutine(SpawnProjectile());
            }
        }
    }

    // spawning eggs 
    private IEnumerator SpawnProjectile()
    {
        shoot = false;
        GameObject projectile = Instantiate(prefab);

        //Physics.IgnoreCollision((Collider) spawnedEgg.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

        Transform tran = transform;
        projectile.transform.right = tran.up;
        projectile.transform.position = tran.position;

        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        Vector3 force = tran.up * projectileForce;
        projectileRb.AddForce(force, ForceMode2D.Impulse);

        // wait for .2 seconds    
        yield return new WaitForSeconds(.2f);
        shoot = true;
    }

}