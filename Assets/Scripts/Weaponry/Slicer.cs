using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slicer : Weapon
{
    // implement grenade launcher style weapon
    // circular projectiles that move slowly and explode on impact dealing damage in a radius.
    public float projectileForce = 10f;
    public float shootInterval = .2f;
    public float spawnOffset = 1f;

    //spawning laser from knife 
    protected override IEnumerator Shoot()
    {
        canShoot = false;
        GameObject spawnedLaser = Instantiate(projectile);

        spawnedLaser.transform.right = this.transform.parent.up;
        spawnedLaser.transform.position = this.transform.position + (transform.parent.up * spawnOffset);

        Rigidbody2D laserRB = spawnedLaser.GetComponent<Rigidbody2D>();

        Vector3 force = transform.parent.up * projectileForce;
        laserRB.AddForce(force, ForceMode2D.Impulse);

        // wait for .4 seconds    
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }

}