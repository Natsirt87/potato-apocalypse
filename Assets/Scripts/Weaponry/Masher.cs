using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Masher : Weapon
{
    public float projectileForce = 10f;
    public float shootInterval = 2f;

    public float spawnOffset = 1f;
    public int numLasers = 5;
    public float spread = 20f;


    // spawning laser from knife 
    protected override IEnumerator Shoot()
    {
        canShoot = false;

        for(int i = 0; i < numLasers; i++)
        {
            GameObject spawnedLaser = Instantiate(projectile);

            spawnedLaser.transform.position = this.transform.position + (transform.parent.up * spawnOffset);
            //spawnedLaser.transform.right = transform.parent.up;

            Vector3 vectorToMouse = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, vectorToMouse);
            rotation *= Quaternion.Euler(0, 0, 90);
            spawnedLaser.transform.rotation = rotation;

            spawnedLaser.transform.Rotate(0f, 0f, -spread / 2 + (((spread) / (numLasers - 1)) * i)); 
            Rigidbody2D laserRB = spawnedLaser.GetComponent<Rigidbody2D>();

            laserRB.velocity = transform.parent.GetComponent<Rigidbody2D>().velocity;
            Vector3 force = spawnedLaser.transform.right * projectileForce;
            laserRB.AddForce(force, ForceMode2D.Impulse);
        }

        // wait for .4 seconds    
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }
}
