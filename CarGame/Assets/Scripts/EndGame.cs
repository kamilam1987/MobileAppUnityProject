using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Author: Kamila Michel

public class EndGame : MonoBehaviour {
    //Declare variables
    public Text GameSummaryText;//text for gained points
    public Text LifeBonusText;//text for lifes bonus
    public Text cleanRideBonusText;//text for clean ride bonus
    public Text totalPointsText;//text for total points

    public int everyExtraLifeBonus;//Amount of points for bonus life
    public int cleanRideBonus; //Amount of points for clean ride

    private GameObject GameManager;//Game object for game manager
    private GameObject PlayerCar;//Game object for plyer car

    void Start()
    {
        GameSummaryText.text = PointsManager.points.ToString();
        GameManager = GameObject.Find("GameManager");
        LifeBonusText.text = (GameManager.GetComponent<CarDurabilityManager>().lifes * everyExtraLifeBonus).ToString();
        //Checks if the player is on scene
        if ((PlayerCar = GameObject.FindWithTag("Player")) != null)//If player exist 
        {
            if (PlayerCar.GetComponent<CarMovement>().durability == PlayerCar.GetComponent<CarMovement>().maxDurability && GameManager.GetComponent<CarDurabilityManager>().lifes == GameManager.GetComponent<CarDurabilityManager>().maxLifes)//Checks if player durability is the same as max durability and checks if no player lifes was lost
            {
                cleanRideBonusText.text = cleanRideBonusText.ToString();//Bonus for 0 collision
            }//End of if
        }//End of if

        //Calculate totals points
        totalPointsText.text = (int.Parse(GameSummaryText.text) + int.Parse(LifeBonusText.text) + int.Parse(cleanRideBonusText.text)).ToString();
    }//End of start method

    //On Play again button
    public void PlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }//End of PlayAgainButton method

    //On back to menu button
    public void BackToMenuButton() {
        SceneManager.LoadScene(0);
    }//End of BackToMenuButton method
}//End of EndGame class
