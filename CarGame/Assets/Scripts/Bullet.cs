using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=iNfjql8m3Bo

public class Bullet : MonoBehaviour {

    //Declare variables
    public int bulletDamage;//Bullet damage
    [HideInInspector]
    public int direction;//Direction of a bullet
    public float bulletSpeed;//Speed of a bullet
    public GameObject explosion;//Explosion object

    //Update method callculates how the bullet is moving
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(direction, 0, 0) * bulletSpeed * Time.deltaTime);
    }//End of Update method

    //On collision with a player car
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")//If game object is player car
        {
            obj.gameObject.GetComponent<CarMovement>().durability -= bulletDamage;//Substract bullet damage from player car durabilty
            GameObject spawnedExplosion =(GameObject)Instantiate(explosion, gameObject.transform.position, Quaternion.identity);//Explosion when car was hit by bullet
            spawnedExplosion.GetComponent<AudioSource>().enabled = false;//Won't play sound when players gets shoot from a police car
            spawnedExplosion.transform.localScale = new Vector3(0.2f, 0.2f, 1f);//Explosion will be smallerthen others explosions
            Destroy(this.gameObject);//Destroy bullet object
        }//End of if   
        else if(obj.gameObject.tag =="Shield" || obj.gameObject.tag == "Barrier" || obj.gameObject.tag == "PoliceCar")//If player has a shield bonus, tag barrier or tag policeCar
        {
            Destroy(this.gameObject);//Destroy bullet object
        }//End of else if
    }//End of OnTriggerEnter2D
}//End of Bullet class
