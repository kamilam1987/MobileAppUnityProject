using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=Ugf7EERyESk

public class CivilCarBehaviour : MonoBehaviour {

    //Declare variables
    public float civilCarSpeed = 5f;//The speed of civil car
    public int direction = -1;//Diretion of a car on the road

    private Vector3 civilCarPosition;//Position of the civil car

    //Update is called once per frame
    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, direction, 0) * civilCarSpeed * Time.deltaTime);//Gives new vector
    }//End of Update method

    private void OnTriggerEnter2D(Collider2D obj)
    {

        if(obj.gameObject.tag == "Player")//Checks if PlayerCar tag is Player
        {
            Debug.Log("Collision with player");//Prints comments
            Destroy(this.gameObject);
        }//End of if
        else if (obj.gameObject.tag == "EndOfTheRoad")//If game object has a tag called "EndOfTheRoad"
        {
            Destroy(this.gameObject);//Destroy game object
        }//End of else if 
    }//End of OnTriggerEnter2D method

}//End of CivilCarBehaviour
