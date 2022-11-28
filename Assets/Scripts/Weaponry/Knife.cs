using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knife : Weapon
{
    public float projectileForce = 10f;
    public float shootInterval = .2f;
    public float spawnOffset = 1f;


    // spawning laser from knife 
    protected override IEnumerator Shoot()
    {
        canShoot = false;
        GameObject spawnedLaser = Instantiate(projectile);

        spawnedLaser.transform.right = transform.parent.up;
        spawnedLaser.transform.position = this.transform.position + (transform.parent.up * spawnOffset);

        Rigidbody2D laserRB = spawnedLaser.GetComponent<Rigidbody2D>();

        Vector3 vectorToMouse = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, vectorToMouse);
        rotation *= Quaternion.Euler(0, 0, 90);
        spawnedLaser.transform.rotation = rotation;
        
        Vector3 force = spawnedLaser.transform.right * projectileForce;
        laserRB.AddForce(force, ForceMode2D.Impulse);

        // wait for .4 seconds    
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }
}
