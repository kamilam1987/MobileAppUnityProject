using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=xlJ4IgjiTXc&t=2s

public class MenuFunctionality : MonoBehaviour {

    //Declare variables
    public Light redLight;//Police car red light
    public Light blueLight;//Police car blue light
    public float lightDeley;//Deley value
    private float delay;//Deley
    public GameObject highScores;//High score object
    public GameObject menuButtons;

    void Start()
    {
        delay = lightDeley;//Assigned light deley to delay
        redLight.enabled = true;
        blueLight.enabled = false;

        if (PlayerPrefsX.GetIntArray("HighScoreArray", 0, 10)[0] == 0) //takes 3 arguments(name, the default values has to assigned if it's not in the system and the default size of array), if the first element is 0 crate this array
        {
            int[] hightScoresinitializationArray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//Array that keeps 10 of highest scores(sets them all to 0 at the start)
                                                                                                //Assigned a whole array of int numbers
            PlayerPrefsX.SetIntArray("HighScoreArray", hightScoresinitializationArray);//Takes two arguments(name and array)
        }//End of if
    }//End of Start method

   

    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0)
        {
            redLight.enabled = !redLight.enabled;
            blueLight.enabled = !blueLight.enabled;
        }//End of if
    }//End of Update method

    //Functions for menu start button
    public void StartButton() {
        SceneManager.LoadScene(1);//Loads scene with id 0
    }//End of StartButton method

    //Functions for menu high score button 
    public void HighScoreButton()
    {
        menuButtons.SetActive(false);//Turns off Menu
        highScores.SetActive(true);//Turns on the high score panel
    }//End of HighScoreButton method

    //Functions for menu options button
    public void OptionsButton() {
        //SceneManager.LoadScene(3);
    }//End of OptionsButton method

    //Functions for menu exit button
    public void ExitButton() {
        Application.Quit();//Exit application
    }//End of ExitButton method

    public void BackToMenuButton() {
        highScores.SetActive(false);//Turns off Highs score panel
        menuButtons.SetActive(true);//Turns on the menu panel
    }//End of BackToMenuButton method

}//End of MenuFunctionality class
