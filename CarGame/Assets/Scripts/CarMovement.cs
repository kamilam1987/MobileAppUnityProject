using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=DucHKKy7-38, https://docs.unity3d.com/ScriptReference/

public class CarMovement : MonoBehaviour {

    //Declares Variables
    public float carHorizontalSpeed = 2f;//Speed of car, moving only on the sides
    private Vector3 carPosition;//Position od the car in game
    public float maxDurability = 100;//Maximum Durability af a player car
    //[HideInInspector]//Makes a variable not show up in the inspector but be serialized
    public float durability;//Current durability

    //Once the game starts
    private void Start()
    {
        carPosition = this.gameObject.transform.position;//Asign to the car position the actual position of the obcject
        durability = maxDurability;//Assigned max durability value to the current durability
    }//End of Start method

    // Update is called once per frame
    private void Update()
    {
        carPosition.x += Input.GetAxis("Horizontal") * carHorizontalSpeed * Time.deltaTime;//Moving left side on left key press and moving right on the right key press
        carPosition.x = Mathf.Clamp(carPosition.x, -5.05f, 5.05f);//Clamp takes the car position and min an max value on the road)Makes sure that the car is on the road, doesn't go beyond the sides of the road
        this.gameObject.transform.position = carPosition; 
    }//End of Update method


}//End of CarMovement class
