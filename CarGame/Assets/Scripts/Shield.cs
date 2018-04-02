 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=UAsK_OqdOGY

public class Shield : MonoBehaviour {

    public float duration;//Time for shield bonus
	
	// Update is called once per frame
	void Update () {
        duration -= Time.deltaTime;//Substract time from shield bonus time
        if (duration <= 0)
        {
            this.gameObject.transform.parent.tag = "Player";//Assigned player tag
            Destroy(this.gameObject);//Destroy shield bonus
        }//End of if 
	}//End of Update method 
}//End of Shield class
