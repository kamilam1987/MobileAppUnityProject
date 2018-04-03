using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code adapted from : https://www.youtube.com/watch?v=OC-qs4hH4I8

public class Explosion : MonoBehaviour {

    //Declare variables
    private float delay = 0.7f;//Delay value
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;//Substract passed time from delay
        if (delay <= 0)
        {
            Destroy(this.gameObject);//Destroy explosion
        }//End of if


    }//End of Update method
}//End of Explosion class
