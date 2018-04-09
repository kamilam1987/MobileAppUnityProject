using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Kamila Michel
//Source code based on:https://www.youtube.com/watch?v=DB7V7Eu6TB0&t=337s

public class HighScores : MonoBehaviour {
    //Declare variables
    public Text highScoreText;//Hight score text
    int[] highScoreArray = new int[10];//Array with the highest score

    void Start()
    {
        highScoreArray = PlayerPrefsX.GetIntArray("HighScoreArray");
        if (highScoreArray[0] == 0)//Checks the first element in the array
        {
            highScoreText.text = "No results";//Because all 0 in the array
        }//End of if
        else
        {
            highScoreText.text = "";//Assignes empty string
            for (int i = 0; highScoreArray[i] != 0; i ++)//If there is any score
            {
                highScoreText.text += (i + 1) + ". " + highScoreArray[i] + " points" + System.Environment.NewLine;//Display high score in a new line, starts from 1
                if(i == 9)
                {
                    break;
                }//End of if
            }//End of for lool
        }//End of else
    }//End of Start method


}//End of HighScores class
