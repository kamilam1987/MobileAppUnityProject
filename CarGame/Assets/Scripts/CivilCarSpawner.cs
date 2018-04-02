using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=Ugf7EERyESk

public class CivilCarSpawner : MonoBehaviour {

    //Declare variables
    public float carSpawnDeley = 2f;//Time delay for car spawn
    public GameObject civilCar;//game object of spanw car

    private float[] laneArray;//Lanes on the road
    private float spawnDelay;//Spawn delay

    //Once the game starts
    void Start()
    {
        laneArray = new float[4];//Four lanes on th road
        laneArray[0] = -4.60f;//For each lane assigned position on the road
        laneArray[1] = -1.76f;
        laneArray[2] = 1.76f;
        laneArray[3] = 4.60f;
        spawnDelay = carSpawnDeley;
    }//End of Start method 

    //Update is calles once per fram
    private void Update()
    {
        spawnDelay -= Time.deltaTime;//Substract passed time
        if(spawnDelay <= 0)
        {
            spawnCar();
            spawnDelay = carSpawnDeley;//if spawn delay less or equal to 0, asign spawn delay to a car spawn delay
        }
    }//End of Update method

    void spawnCar()
    {
        int lane = Random.Range(0, 4);//Picks random lane
        if (lane == 0 || lane == 1)
        {
            GameObject car = (GameObject)Instantiate(civilCar, new Vector3(laneArray[lane], 6.24f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));//Creates a new object, position and rotation by 180 degrees
            car.GetComponent<CivilCarBehaviour>().direction = 1;//Car will moves in different direction
            car.GetComponent<CivilCarBehaviour>().civilCarSpeed = 12f;//Chanfes the speed of a car that is moving in different direction
        }
        if(lane == 2 || lane == 3) { 
            Instantiate(civilCar, new Vector3(laneArray[lane], 6.24f, 0), Quaternion.identity);//Creates a new object, position and rotation
        }//End of if
    }//End of spawnCar method


}//End of CivilCarSpawner class
