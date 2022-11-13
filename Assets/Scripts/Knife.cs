using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knife : Weapon
{
    public float projectileForce = 10f;
    public float shootInterval = .2f;


    // spawning laser from knife 
    protected override IEnumerator Shoot()
    {
        canShoot = false;
        GameObject spawnedLaser = Instantiate(projectile);

        spawnedLaser.transform.right = this.transform.parent.up;
        spawnedLaser.transform.position = this.transform.position;

        Rigidbody2D laserRB = spawnedLaser.GetComponent<Rigidbody2D>();

        Vector3 force = transform.parent.up * projectileForce;
        laserRB.AddForce(force, ForceMode2D.Impulse);

        // wait for .4 seconds    
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }
}
