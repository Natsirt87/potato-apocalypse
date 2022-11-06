using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private bool shoot = true;
    public GameObject prefab; 

    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
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
        // Rigidbody2D eggRB;
        // eggRB.AddForce();
        shoot = false;
        GameObject spawnedEgg = Instantiate(prefab);
        spawnedEgg.transform.up = this.transform.up;
        spawnedEgg.transform.position = this.transform.position;

        yield return new WaitForSeconds(.2f);
        shoot = true;
    }


}