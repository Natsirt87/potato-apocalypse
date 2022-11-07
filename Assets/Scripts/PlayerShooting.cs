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

    void Start()
    {
       
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(shoot)
            {
                StartCoroutine(SpawnProjectile());
            }
        }
    }

    // spawning eggs 
    protected IEnumerator SpawnProjectile()
    {
        shoot = false;
        GameObject spawnedLaser = Instantiate(prefab);

        //Physics.IgnoreCollision((Collider) spawnedEgg.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

        spawnedLaser.transform.right = this.transform.up;
        spawnedLaser.transform.position = this.transform.position;

        Rigidbody2D laserRB = spawnedLaser.GetComponent<Rigidbody2D>();

        Vector3 force = transform.up * projectileForce;
        laserRB.AddForce(force, ForceMode2D.Impulse);

        // wait for .2 seconds    
        yield return new WaitForSeconds(.2f);
        shoot = true;
    }


}