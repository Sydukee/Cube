using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

    private string[] identity;
    private bool isAlive;



    public bool doorDirection = true;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
       
        
    }

    

   
    public void OnTriggerStay(Collider other)
    {
        
        if(other.tag == Tags.door1&&Input.GetKeyDown(KeyCode.F))
        {
            other.gameObject.GetComponentInParent<Door>().ChangeDoorState();
            doorDirection = true;
         
        }
        if (other.tag == Tags.door2 && Input.GetKeyDown(KeyCode.F))
        {
            other.gameObject.GetComponentInParent<Door>().ChangeDoorState();
            doorDirection = false;

        }
    }


    public bool getIsAlive()
    {
        return isAlive;
    }
    public void setIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

}
