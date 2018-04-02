using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=UAsK_OqdOGY

public class Bonuses : MonoBehaviour {

    [Header("Type of bonus")]
    //Declare variables
    public bool isDurability;//Durability bonus
    public bool isShield;//Shield bonus
    public bool isSpeed;//Speed bonus

    [Header("Bonuses Settings")]
    public float bonusSpeed = 10f;//speed of a bonus

    [Header("Durability Settings")]
    public float repairPoints;//Repat points for durability

    [Header("Shield Settings")]
    public GameObject shield; //Shield game object
    private GameObject playerCar;//Position of a car
    private Vector3 playerCarPos;//Vector3 of car position

    [Header("Speed Settings")]
    public float speedBoost;//Value of a speed boost
    public float duration;//the amount of time from speed boost
    private bool isActivated = false;//Activity of a bonus

    // Update is called once per frame, changes positions of a bonuses
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * bonusSpeed * Time.deltaTime);//Will be droping the bonuses
    }

    //Once player hit the bonus it will collect it
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player" || obj.gameObject.tag == "Shield")//If shield can add other bonuses
        {
            //Checks what type of bonus
            if (isDurability == true)//IF bonus is durability
            {
                obj.gameObject.GetComponent<CarMovement>().durability += repairPoints;//Adds repairs points
                Destroy(this.gameObject);//Destroy bonus object
            }//End of if
            else if (isShield == true)//IF bonus is shield
            {
                playerCar = GameObject.FindWithTag("Player");//Finds object with Player tag
                obj.gameObject.tag = "Shield";//Change tag to shield
                playerCarPos = playerCar.transform.position;//Assigned actual position of a 
                playerCarPos.z = -0.1f;//Shows the light
                GameObject shieldObj = (GameObject)Instantiate(shield, playerCarPos, Quaternion.identity);//Creates shield game object
                shieldObj.transform.parent = playerCar.transform;//Change the parent
                Destroy(this.gameObject);//Destroy game object
            }//End of else if
            else if (isSpeed = true)//If bonus is speed
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;//Bonus won't be visible
                isActivated = true;
                StartCoroutine("SpeedBoostActivated");
            }//End of else if
        }//End of if
        else if (obj.gameObject.tag == "End" && isActivated == false)//Destroy once reach the box collider
        {
            Destroy(this.gameObject);//Destroy bonus game object
        }
    }//End of OnTriggerEnter2D method
   IEnumerator SpeedBoostActivated()
    {
        while(duration > 0)//Duration exist
        {
            duration -= Time.deltaTime / speedBoost;//Speed of a game
            Time.timeScale = speedBoost;//Scales how the time goes
            yield return null;
        }//End of while
        Time.timeScale = 1f;//Time will back to 1 
        Destroy(this.gameObject);//Destroy bonus game object
    }//End of SpeedBoostActivated IEnumerator
}//End of Bonuses class
