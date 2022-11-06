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

    // shooting eggs
    protected IEnumerator SpawnProjectile()
    {
        shoot = false;
        GameObject spawnedEgg = Instantiate(prefab);
        spawnedEgg.transform.up = this.transform.up;
        spawnedEgg.transform.position = this.transform.position;

        //spawnedEgg.GetComponent<EggBehavior>().eggCount = this;

        //slider.transform.localScale = new Vector3(1, 2, 0);

        yield return new WaitForSeconds(.2f);
        shoot = true;
    }

}