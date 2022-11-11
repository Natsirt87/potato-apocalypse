using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeShooting : MonoBehaviour
{
    public bool shoot2 = true; // for knife
    public GameObject prefab; 
    public float projectileForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // shooting from knife
        if(Input.GetKey("k"))
        {
            if(shoot2)
            {
                StartCoroutine(SpawnFromKnife());
            }
        } 
    }

    // spawning laser from knife 
    public IEnumerator SpawnFromKnife()
    {
        shoot2 = false;
        GameObject spawnedLaser2 = Instantiate(prefab);

        spawnedLaser2.transform.right = this.transform.parent.up;
        spawnedLaser2.transform.position = this.transform.position;

        Rigidbody2D laserRB2 = spawnedLaser2.GetComponent<Rigidbody2D>();

        Vector3 force2 = transform.parent.up * projectileForce;
        laserRB2.AddForce(force2, ForceMode2D.Impulse);

        // wait for .4 seconds    
        yield return new WaitForSeconds(.5f);
        shoot2 = true;
    }
}
