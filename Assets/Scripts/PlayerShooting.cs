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
        GameObject spawnedEgg = Instantiate(prefab);

        //Physics.IgnoreCollision((Collider) spawnedEgg.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

        spawnedEgg.transform.right = this.transform.up;
        spawnedEgg.transform.position = this.transform.position;
        

        float value = 5f;
        Rigidbody2D eggRB = spawnedEgg.GetComponent<Rigidbody2D>();

        Vector3 force = transform.up * value;
        eggRB.AddForce(force, ForceMode2D.Impulse);

        // wait for .2 seconds    
        yield return new WaitForSeconds(.2f);
        shoot = true;
    }


}