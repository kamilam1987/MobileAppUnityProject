using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=Ugf7EERyESk

public class WaveManager : MonoBehaviour {

    //Declare variables

    [Header("Wave 1 (Civil Cars")]
    public float civilCarSpawnDeley;//Time delay for car spawn
    public GameObject civilCar;//game object of spanw car
    public int civilCarAmount;//Amount of civil cars
    [Header("Wave 2 (Bandit Cars")]
    public GameObject banditCar;//Object of a bandit car
    public int bombAmount;//Amount of bombs
    public int banditCarVarticalSpeed;
    public int banditCarHorizontalSpeed;
    public float bombDelay;//Bombs delay
    private GameObject spawnedBanditCar;//Object for spawned bandit car
    private bool isSpawned;//Spawn first bandit car
    private bool isSecondSpawn;//Spawn second bandit car
    [Header("Wave 3 (Police Cars")]
    public GameObject policeCar;//Police car object
    public int policeCarAmount;//Amount of police cars  
    [HideInInspector]
    static public bool isLeft;//Side of the road where is police car
    [HideInInspector]
    static public bool isRight;//Side of the road where is police car
    public float shootingSeriesDelay;//Series delay
    public float singleShotDelay;//Shot delay
    public float policeCarVerticalSpeed;//Speed of a police car
    public int bulletsInSeries;//Amount of bullets in one serie 
    private GameObject spawnedPoliceCar;//Object for spawned police car

    [Header("Points")]
    public int pointsPerCivilCar;//Amount of points that player gets for civil car
    public int pointsPerBamditCar;//Amount of points that player gets for bandits car
    public int pointsPerBomb;//Amount of points that player gets for skipping a bomb
    public int pointsPerPoliceCar;//Amount of points that player gets for damage police car
    private float[] laneArray;//Lanes on the road
    private float spawnDelay;//Spawn delay

    public GameObject EndGameScreen;//Screen with points

    //Once the game starts
    void Start()
    {
        laneArray = new float[4];//Four lanes on th road
        laneArray[0] = -4.60f;//For each lane assigned position on the road
        laneArray[1] = -1.76f;
        laneArray[2] = 1.76f;
        laneArray[3] = 4.60f;
        spawnDelay = civilCarSpawnDeley;
    }//End of Start method 

    //Update is calles once per fram
    private void Update()
    {
        spawnDelay -= Time.deltaTime;//Substract passed time
        if (spawnDelay <= 0 && civilCarAmount > 0)//Checks if any civl cars left
        {
            spawnCar();
            spawnDelay = civilCarSpawnDeley;//if spawn delay less or equal to 0, asign spawn delay to a car spawn delay
        }
        else if (civilCarAmount <= 0 && isSecondSpawn == false)//If no more civils car and second car is not spowned
        {
            if(isSpawned == false) { //Checks if first bandit car wasn't spawn
                spawnBanditCar();//Run spawnBanditCar method
            }//End of if
            else if(isSpawned == true && spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombAmount < 5 && isSecondSpawn == false)//If bomb amount is less then 5 creates second bandit car)
            { 
                spawnBanditCar();//Run spawnBanditCar method
            }
        }//End of else if
        else if (civilCarAmount <= 0 && policeCarAmount > 0 && spawnedBanditCar == null)//Checks if any civil car exist and any police car for spawning and no bandits car left
        {
            spawnPoliceCar();//Runs spawnedPoliceCar method
        }//End of else if
        else if(policeCarAmount <=0 && isLeft == false && isRight ==false)
        {
            Time.timeScale = 0;
            EndGameScreen.SetActive(true);
        }//End of else if
    }//End of Update method

    //This method checks on which side of the road is player car and police car will be created on opposite road side
    void spawnPoliceCar()
    {
        Transform playerCarPosition;
        //Checks for each tags
        if(GameObject.FindWithTag("Player"))//If player has a tag player
        {
            playerCarPosition = GameObject.FindWithTag("Player").transform;
        }//End of if
        else if(GameObject.FindWithTag("Shield"))//If palyer has tag shields
        {
            playerCarPosition = GameObject.FindWithTag("Shield").transform;
        }//End of else if
        else if(GameObject.FindWithTag("Untouchable")) {
            playerCarPosition = GameObject.FindWithTag("Untouchable").transform;
        }//End of else if
        else
        {
            playerCarPosition = null;
        }//End of else
        if (playerCarPosition.position.x <= -0.93f && isRight == false )//Player car on the left side of the road and no police ar on the right side of the road
        {
            spawnedPoliceCar = (GameObject)Instantiate(policeCar, new Vector3(5.03f, -7.48f, 0), Quaternion.identity);
            spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().isLeft = false;
            isRight = true;
            policeCarAmount--;//Decrease police cas by one
        }//End of if
        else if (playerCarPosition.position.x > -0.93f && isLeft == false)//Player car on the right side of the road and no police ar on the left side of the road
        {
            spawnedPoliceCar = (GameObject)Instantiate(policeCar, new Vector3(-5.03f, -7.48f, 0), Quaternion.identity);
            spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().isLeft = true;
            isLeft = true;
            policeCarAmount--;//Decrease police cas by one
        }//End of else if
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().shootingSeriesDelay = shootingSeriesDelay;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().singleShotDelay = singleShotDelay;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().bulletsInSeries = bulletsInSeries;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().policeCarVerticalSpeed = policeCarVerticalSpeed;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().pointsPerCar = pointsPerPoliceCar;
    }//End of spawnedPoliceCar method

    void spawnBanditCar()
    {
        if (isSpawned == false) //If didn't create oneof the bandit car 
        {
           spawnedBanditCar = (GameObject)Instantiate(banditCar, new Vector3(Random.Range(-5.02f, 5.02f), 7.66f, 0), Quaternion.identity);//Creates bandit car object with random position and default rotation
           isSpawned = true;
        }//End of if
        else if (isSpawned == true && isSecondSpawn == false)
        {
            if (spawnedBanditCar.transform.position.x < -1.12f)//Checks position x of bandit car
            {
                spawnedBanditCar = (GameObject)Instantiate(banditCar, new Vector3(4.92f ,7.66f, 0), Quaternion.identity);//Creates bandit car object with random position and default rotation
                isSecondSpawn = true;
            }//End of if
            else if (spawnedBanditCar.transform.position.x >= -1.12f)//Checks position x of bandit car
            {
                spawnedBanditCar = (GameObject)Instantiate(banditCar, new Vector3(-4.92f, 7.66f, 0), Quaternion.identity);//Creates bandit car object with random position and default rotation
                isSecondSpawn = true;
            }//End of else if
        }//End of if
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombAmount = bombAmount;//Assigned to WaveManager script from Banditcarbehaviour script
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().banditCarVarticalSpeed = banditCarVarticalSpeed;
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().banditCarHorizontalSpeed = banditCarHorizontalSpeed;
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombDelay = bombDelay;
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().pointsPerCar = pointsPerPoliceCar;
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().bomb.GetComponent<Bomb>().pointsPerBomb = pointsPerBomb;
        
    }//End of spawnBanditCar method

    void spawnCar()
    {
        int lane = Random.Range(0, 4);//Picks random lane
        if (lane == 0 || lane == 1)
        {
            GameObject car = (GameObject)Instantiate(civilCar, new Vector3(laneArray[lane], 6.24f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));//Creates a new object, position and rotation by 180 degrees
            car.GetComponent<CivilCarBehaviour>().direction = 1;//Car will moves in different direction
            car.GetComponent<CivilCarBehaviour>().civilCarSpeed = 12f;//Chanfes the speed of a car that is moving in different direction
            car.GetComponent<CivilCarBehaviour>().pointsPerCar = pointsPerCivilCar;//Assigne points for civil car

        }
        if(lane == 2 || lane == 3) {
            GameObject car = (GameObject)Instantiate(civilCar, new Vector3(laneArray[lane], 6.24f, 0), Quaternion.identity);//Creates a new object, position and rotation
            car.GetComponent<CivilCarBehaviour>().pointsPerCar = pointsPerCivilCar;//Assigne points for civil car

        }//End of if
        civilCarAmount--; //Substract one car each time is spawn
    }//End of spawnCar method


}//End of CivilCarSpawner class
