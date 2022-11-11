using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public MasherShooting masher;
    public KnifeShooting knife;

    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
        // shooting from both
        if(Input.GetKey(KeyCode.Space))
        {
            if(masher.shoot && knife.shoot2)
            {
                StartCoroutine(masher.SpawnFromMasher());
                StartCoroutine(knife.SpawnFromKnife());
            }
        }
    }

}