using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=Ugf7EERyESk

public class CivilCarBehaviour : MonoBehaviour {

    //Declare variables
    public float civilCarSpeed = 5f;//The speed of civil car
    public int direction = -1;//Diretion of a car on the road
    public float crashDamage = 20f;//Value of a crash damage

    private Vector3 civilCarPosition;//Position of the civil car

    //Update is called once per frame
    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, direction, 0) * civilCarSpeed * Time.deltaTime);//Gives new vector
    }//End of Update method

    //On collision with civil 
    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag == "Player")//If the tag is player
        {
            obj.gameObject.GetComponent<CarMovement>().durability -= crashDamage / 5;//Makes less damage when car is hit only from a side
        }
    }//End of OnCollisionEnter2D method

    private void OnTriggerEnter2D(Collider2D obj)
    {

        if(obj.gameObject.tag == "Player")//Checks if PlayerCar tag is Player
        {
            obj.gameObject.GetComponent<CarMovement>().durability -= crashDamage;//Substract from durability a cras damage
            Debug.Log("Collision with player");//Prints comments
            Destroy(this.gameObject);
        }//End of if
        else if (obj.gameObject.tag == "EndOfTheRoad")//If game object has a tag called "EndOfTheRoad"
        {
            Destroy(this.gameObject);//Destroy game object
        }//End of else if 
    }//End of OnTriggerEnter2D method

}//End of CivilCarBehaviour
