using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MasherShooting : MonoBehaviour
{
    public bool shoot = true; // for masher
    public GameObject prefab; 
    public float projectileForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // shooting from masher
        if(Input.GetKey("m"))
        {
            if(shoot)
            {
                StartCoroutine(SpawnFromMasher());
            }
        }
    }

    // spawning laser from masher 
    public IEnumerator SpawnFromMasher()
    {
        shoot = false;
        GameObject spawnedLaser = Instantiate(prefab);

        spawnedLaser.transform.right = this.transform.parent.up;
        spawnedLaser.transform.position = this.transform.position;

        Rigidbody2D laserRB = spawnedLaser.GetComponent<Rigidbody2D>();

        Vector3 force = transform.parent.up * projectileForce;
        laserRB.AddForce(force, ForceMode2D.Impulse);

        // wait for .2 seconds    
        yield return new WaitForSeconds(.2f);
        shoot = true;
    }
}
