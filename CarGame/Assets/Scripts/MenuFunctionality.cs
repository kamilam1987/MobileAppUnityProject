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

    void Start()
    {
        delay = lightDeley;//Assigned light deley to delay
        redLight.enabled = true;
        blueLight.enabled = false;
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
        //SceneManager.LoadScene(2);
    }//End of HighScoreButton method

    //Functions for menu options button
    public void OptionsButton() {
        //SceneManager.LoadScene(3);
    }//End of OptionsButton method

    //Functions for menu exit button
    public void ExitButton() {
        Application.Quit();//Exit application
    }//End of ExitButton method

}//End of MenuFunctionality class
