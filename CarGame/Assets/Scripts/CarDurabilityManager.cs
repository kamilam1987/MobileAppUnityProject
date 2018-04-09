using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=zc66JTX_Akg, https://docs.unity3d.com/ScriptReference/

public class CarDurabilityManager : MonoBehaviour {
    //Declare variables
    public GameObject playerCarPrefab;//Object of a playerCarPrefab
    public GameObject spawnPoint;//Pleace when spawn the object once is destroyed
    public TextMesh durabilityText;
    public int lifes;//The amount of lifes that a car has
    private GameObject playerCar;//Private objec of a car
    [HideInInspector]
    public int maxLifes;//Amount of max player lifes at the start
    public GameObject EndGameScreen;//End of the game panel 

    private void Start()
    {
        durabilityText.GetComponent<MeshRenderer>().sortingLayerName = "Durability";//Getsmesh renderer and change the layer
        maxLifes = lifes;//Assignes lifes to max lifes
        playerCar = (GameObject)Instantiate(playerCarPrefab, spawnPoint.transform.position, Quaternion.identity);//Creates a car

    }//End of Start method

    //Checks how much of durability left
    void Update()
    {
        if (playerCar.GetComponent<CarMovement>().durability <= 0)
        {
            Destroy(playerCar);//Destroy a car object
            lifes--;//Substract one of the lifes
            if (lifes > 0)//Checks if any lifes left
            {
                //StartCoroutine function always returns immediately, however you can yield the result. This will wait until the coroutine has finished execution. There is no guarantee that coroutines end in the same order that they were started, even if they finish in the same frame.
                StartCoroutine("SpawnaCar");
            }
            else if (lifes <=0)//No more lifes
            {
                Time.timeScale = 0;//Stops game
                EndGameScreen.SetActive(true);//Activate this panel
            }
        }//End of if
        else if (playerCar.GetComponent<CarMovement>().durability > playerCar.GetComponent<CarMovement>().maxDurability)
        {
            playerCar.GetComponent<CarMovement>().durability = playerCar.GetComponent<CarMovement>().durability;
        }//End of else if

        //Set text to be actual
        durabilityText.text = "Durability : " + playerCar.GetComponent<CarMovement>().durability + "/" + playerCar.GetComponent<CarMovement>().maxDurability;
    }//End of Update method

    IEnumerator SpawnaCar()
    {
        playerCar = (GameObject)Instantiate(playerCarPrefab, spawnPoint.transform.position, Quaternion.identity);//Creates a car
        playerCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);//Only change the transparency
        playerCar.GetComponent<BoxCollider2D>().isTrigger = true;//Player car won't affect to civil cars
        playerCar.tag = "Untouchable";
        yield return new WaitForSeconds(3);//Car will be indestructible for 3 sec
        playerCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);//After 3 sec back to previous color 
        playerCar.GetComponent<BoxCollider2D>().isTrigger = false;//After 3 sec back to normal
        playerCar.tag = "Player";//back to a player tag
    }

}//End of CarDurabilityManager class
