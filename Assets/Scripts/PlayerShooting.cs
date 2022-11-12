using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    
    public List<Weapon> weapons;
    
    
    // Update is called once per frame
    void Update()
    {
        // shooting from both
        if(Input.GetKey(KeyCode.Space))
        {
            foreach (Weapon weapon in weapons)
            {
                weapon.TryShoot();
            }
        }
    }

}