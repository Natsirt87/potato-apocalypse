using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject projectile;

    [SerializeField] protected string shootKey;
    protected bool canShoot = true;


    void Update()
    {
       // shooting from knife
        if(Input.GetKey(shootKey))
        {
            TryShoot();
        } 
    }

    public void TryShoot() 
    {
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    protected virtual IEnumerator Shoot() {yield return new WaitForSeconds(.1f);}
}
