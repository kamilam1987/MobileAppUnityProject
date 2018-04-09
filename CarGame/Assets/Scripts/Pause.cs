using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Author: Kamila Michel

public class Pause : MonoBehaviour {

    //Declare variables
    public GameObject pauseObj;//Pause object
    private float tempTimeScale;//Value for time scale when pause is on(stops the game)

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if(Time.timeScale != 0) { 
                tempTimeScale = Time.timeScale;
            }//End of if
            PauseGame();//Runs pause method
        }//End of if
    }//End of Update method

    //Stops the game
    void PauseGame() {
        pauseObj.SetActive(!pauseObj.activeInHierarchy);//If active in hierrarhy deaactivate pause
        if (Time.timeScale != 0)//If it's not 0
        {
            Time.timeScale = 0;//Assigned 0 to the time scale
        }//End of if
        else
        {
            Time.timeScale = tempTimeScale;
        }//End of else
    }//End of PauseGame method

    //On resume button
    public void ResumeButton()
    {
        PauseGame();
    }//End of ResumeButton method

    //On Menu exit
    public void MenuExitButton() {
        SceneManager.LoadScene(0);
    }//End of MenuExitButton method

    //On Exit button
    public void ExitButton() {
        Time.timeScale = 1;//Starts time
        Application.Quit();//Exit game
    }//End of ExitButton method
}//End of Pause class
