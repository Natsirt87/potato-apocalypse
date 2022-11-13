using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Masher : Weapon
{
    public float projectileForce = 10f;
    public float shootInterval = 2f;


    // spawning laser from knife 
    protected override IEnumerator Shoot()
    {
        canShoot = false;

        int numOfLasers = 3;
        float angleRange = -10;
        for(int i = 0; i < numOfLasers; i++)
        {
            GameObject spawnedLaser = Instantiate(projectile);

            spawnedLaser.transform.right = this.transform.parent.up;
            spawnedLaser.transform.position = this.transform.position;

            spawnedLaser.transform.Rotate(0f, 0f, angleRange); 
            angleRange+=10;
            Rigidbody2D laserRB = spawnedLaser.GetComponent<Rigidbody2D>();

            Vector3 force = spawnedLaser.transform.right * projectileForce;
            laserRB.AddForce(force, ForceMode2D.Impulse);
        }

        // wait for .4 seconds    
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }
}
