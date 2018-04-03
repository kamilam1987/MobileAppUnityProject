using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=42LU2PO9BAY

public class Bomb : MonoBehaviour {
    //Declare variables
    public int bombDamage;//Value of damage that the bomb makes
    public float bombSpeed;//Value of a bomb speed

    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * bombSpeed * Time.deltaTime);//Object will fall down
    }//End of Update method

    //On collision
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")//If tag of that object is player
        {
            obj.gameObject.GetComponent<CarMovement>().durability -= bombDamage;//From car durability substract damage made from bomb
            Destroy(this.gameObject);//Destroy bomb
        }//End of if 
        else if(obj.gameObject.tag == "Shield")//Have a tag shield
        {
            Destroy(this.gameObject);//Destroy bomb
        }//End of else if
        else if(obj.gameObject.tag == "EndOfTheRoad")//If tag is EndOfTheRoad
        {
            Destroy(this.gameObject);//Destroy bomb
        }//End of else if
    }//End of OnTriggerEnter2D method

}//End of Bomb class
