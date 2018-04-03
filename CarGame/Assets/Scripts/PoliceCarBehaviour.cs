using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=iNfjql8m3Bo

public class PoliceCarBehaviour : MonoBehaviour {

    //Declare Variables
    public Light redLight;//Police car red light
    public Light blueLight;//Police car blue light
    public float lightDelay;//Speed of lights
    public GameObject bullet;//Bullet object
    public float shootingSeriesDelay;//Series delay
    public float singleShotDelay;//Shot delay
    //[HideInInspector]
    public bool isLeft=false;//Side of a police car on the road
    public float policeCarVerticalSpeed;//Speed of a police car
    public int bulletsInSeries;//Amount of bullets in one serie

    private Vector3 policeCarPos;//Police car position
    private float shootDelay;//Time for shooting
    private GameObject bulletObj;//Bullet object
    private float lightShowDelay; 

    void Start()
    {
        lightShowDelay = 2 * lightDelay;
        shootDelay = shootingSeriesDelay;//Assigned series delay to shoot delay
    }//End of Start method

    //Upsdate method calculate where to stop police car
    void Update()
    {
        lightShowDelay -= Time.deltaTime;//Substract passed time 
        if (lightShowDelay > lightDelay)
        {
            blueLight.enabled = false;//turn off the blue light
            redLight.enabled = true;//turn on the red light
        }//End of if
        else if(lightShowDelay <= lightDelay && lightShowDelay >0)
        {
            blueLight.enabled = true;//turn on the blue light
            redLight.enabled = false;//turn off the red light
        }
        else if(lightShowDelay <= 0)
        {
            lightShowDelay = 2 * lightDelay;//Lights swaps from blue to red
        }//End of else if
        //Checks Spawn point
        if(gameObject.transform.position.y < -3.54f)
        {
            gameObject.transform.Translate(new Vector3(0, 1, 0) * policeCarVerticalSpeed * Time.deltaTime);//Moves the police car object up
        }//End of if 
        else //On the position
        {
            shootDelay -= Time.deltaTime;//Passed time
            if(shootDelay <= 0)
            {
                StartCoroutine("Shoot");
                shootDelay = shootingSeriesDelay;
            }//End of if
        }//End of else
    }//End of Update method
    IEnumerator Shoot()
    {
        //Amount of bullets series
        for(int i = bulletsInSeries; i>0; i-- )
        {
            bulletObj = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);//Assigned a new bullet object in the same pleace where is a police car
            //Direction of a bullet
            if(isLeft == true)//Police car is on the left side of the road
            {
                bulletObj.GetComponent<Bullet>().direction = 1;
            }//End of if  
            else if (isLeft == false)//Police car is on the right side of the road
            {
                bulletObj.GetComponent<Bullet>().direction = -1;
            }//End of else if
            yield return new WaitForSeconds(singleShotDelay);//Return shoot delay
        }//End of for loop
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag == "Barrier")//Object has tag Barrier
        {
            if(isLeft == true)
            {
                WaveManager.isLeft = false;//This car exploded on the left side of the road
            }//End of if
            else if(isLeft == false)
            {
                WaveManager.isRight = false;//Car on the right side of the road will explode
            }
            Destroy(this.gameObject);//Destroy object
        }//End of if

    }//End of OnCollisionEnter2D method
}//End of PoliceCarBehaviour class
