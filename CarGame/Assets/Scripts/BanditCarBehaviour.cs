using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code adapted from: https://www.youtube.com/watch?v=42LU2PO9BAY

public class BanditCarBehaviour : MonoBehaviour {
    //Declare variables
    public GameObject bomb;//Bobm game object
    public int bombAmount;//Amount of bombs
    public int banditCarVarticalSpeed;
    public int banditCarHorizontalSpeed;
    public float bombDelay;//Bombs delay

    private float Delay;//Deley amount
    private GameObject playerCar;//Object car player
    private Vector3 banditCarPos;//Position of a bandits car

    void Start()
    {
        playerCar = GameObject.FindWithTag("Player");//Find car with game player
        Delay = bombDelay;//Assigneddelay to bomb delay
    }//End of Start method

    void Update()
    {
        if(playerCar == null)//If didn't find a player car
        {
            playerCar = GameObject.FindWithTag("Player");//Looks for object with player tag 
        }//End of if
         else
        {
            if (gameObject.transform.position.y > 2.65f && bombAmount > 0)
            {
                this.gameObject.transform.Translate(new Vector3(0, -1, 0) * banditCarVarticalSpeed * Time.deltaTime);//Speed of driving in and out
            }//End of if
            else if (bombAmount <= 0) {//No more bombs
                this.gameObject.transform.Translate(new Vector3(0, 1, 0) * banditCarVarticalSpeed * Time.deltaTime);//Bandits car disappear 
                if (gameObject.transform.position.y > 8.26f) {//If on the position
                    Destroy(this.gameObject);
                }//End of if
            }//End of else if
            else
            {
                banditCarPos = Vector3.Lerp(transform.position, playerCar.transform.position, Time.fixedDeltaTime * banditCarHorizontalSpeed);//Follows the player car
                transform.position = new Vector3(banditCarPos.x, transform.position.y, 0);//How fast will be moving

                //Check if delay accept to drop a bomb
                Delay -= Time.deltaTime;
                if (Delay <= 0 && bombAmount > 5) //If delay 0 or and 5 bombs left
                {
                    Delay = bombDelay; //Assignrd bomb delay
                    bombAmount--;
                    Instantiate(bomb, transform.position, Quaternion.identity);//Drops bomb
                }//End of if
                else if(Delay <= 0 && bombAmount <= 5 && bombAmount > 0)
                {
                    Delay = bombDelay / 2; //Assignrd bomb delay twice faster
                    bombAmount--;
                    Instantiate(bomb, transform.position, Quaternion.identity);//Drops bomb
                }//End of else if
            }
        }//End of else
    }//End of Update method
}//End of BanditCarBehaviour class
