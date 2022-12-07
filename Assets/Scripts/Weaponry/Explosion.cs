using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour{

    //public Time timer = 5f;

    void Start()
    {
        GetComponent<Animator>().Play("exploAni");
        Destroy(gameObject, .4f);
    }

}