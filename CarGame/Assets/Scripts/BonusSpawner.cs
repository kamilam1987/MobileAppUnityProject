using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=BybD88xJskc

public class BonusSpawner : MonoBehaviour {

    //Declare variables
    private float delay;//Amount of time for showing bonuses
    public GameObject[] bonuses;  //Types of bonuses
    public int minDelay;//Value for minimum delay
    public int maxDelay;//Value for maximum delay

    //Random delay
    void Start()
    {
        delay = Random.Range(minDelay, maxDelay);//Assigned delay to random delay
    }//End od Start  

    private void Update()
    {
        delay -= Time.deltaTime;//Passed time
        if(delay <= 0)
        {
            delay = Random.Range(minDelay, maxDelay);//Assigned delay to random delay
            SpawnBonus();//Creates bonuses
        }//End of if
    }//End of Update method

    void SpawnBonus() {
        Instantiate(bonuses[(int)Random.Range(0, 3)], new Vector3(Random.Range(-5.46f, 5.46f), 6f, 0), Quaternion.identity); //Cretes one of the bonuses
    }//End of SpawnBonus method


}//End of BonusSpawner class
