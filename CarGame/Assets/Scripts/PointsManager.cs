using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=GkBVdEqs1ag
public class PointsManager : MonoBehaviour {

    //Declare variables
    static public int points;//Amount of points
    private float secondDelay = 1; //Delay value

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Points";//Display under a cars
        this.gameObject.GetComponent<TextMeshPro>().color = new Color(1f, 1f, 1f, 0.7f);//Adds transparency
	}

    //This method callculates points
    void Update()
    {
        this.gameObject.GetComponent<TextMeshPro>().text = points.ToString(); //Points value
        secondDelay -= Time.deltaTime;
        
        if(secondDelay <= 0)
        {
            points += 1;//Adds points every 1 sec
            secondDelay = 1;//Assigned value of 1
        }//End of if

    }//End of Update method


}//End of PointsManager class
