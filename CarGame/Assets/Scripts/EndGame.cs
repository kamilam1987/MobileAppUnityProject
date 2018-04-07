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

    private int score;//Score value
    private int[] highScoresArray = new int[10];//Array with the 10 highest scores
    void Start()
    {
        highScoresArray = PlayerPrefsX.GetIntArray("HighScoreArray");//Crates high score array
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

        //Calculate totals points as a text
        totalPointsText.text = (int.Parse(GameSummaryText.text) + int.Parse(LifeBonusText.text) + int.Parse(cleanRideBonusText.text)).ToString();
        //Parses points to int
        score = int.Parse(totalPointsText.text);
        //Checks if the score is higher then the last element in the array
        if(score > highScoresArray[9])
        {
            for (int i = 0; i < 10; i++)//Loops the array to add a high score
            {
                if (score > highScoresArray[i])//Check if score is higher then the pleace in array that is in
                {
                    for (int j = 9; j > i; j--)//Scores go down by one in the array
                    {
                        highScoresArray[j] = highScoresArray[j - 1];
                    }//End of for
                    highScoresArray[i] = score;//Found the pleace in the array
                    break;//Found the pleace so it won't look for more
                }//End of if
            }//End of for loop

        }//End of if

        PlayerPrefsX.SetIntArray("HighScoreArray", highScoresArray);//Adds result to the high score array
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
