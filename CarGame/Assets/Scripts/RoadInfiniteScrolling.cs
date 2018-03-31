using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on : https://www.youtube.com/watch?v=0ZZlMIZyPUk

public class RoadInfiniteScrolling : MonoBehaviour {

    //Declares variables
    public float scrollSpeed;
    private Vector2 offset;

    private void Update()
    {
        offset = new Vector2(0, Time.time * scrollSpeed); //Time and speed
        GetComponent<Renderer>().material.mainTextureOffset = offset;//Gets component from object which script is assigned to, assigne offset to object texture
    }//End of Update method
}//End of RoadInfiniteScrolling class
