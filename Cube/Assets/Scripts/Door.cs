using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Door : NetworkBehaviour {

    private Animator anim;
    private string openDoor = "OpenDoor";
    private string closeDoor = "CloseDoor";
    public  bool isDoorOpen = false;
    private string tag;

    public GameObject Person;
    public GameObject[] Players;


    private void Update()
    {
        Players = GameObject.FindGameObjectsWithTag(Tags.person);
        foreach (GameObject p in Players)
        {
            if (p.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                Person = p;
            }
        }
    }
    void Start () {
        anim = this.GetComponent<Animator>();
        Person = GameObject.FindGameObjectWithTag(Tags.person);
        tag = this.gameObject.tag;
        
	}
	
    [ClientRpc]
    public void RpcChangeDoorState()
    {
        print(1);
        if (Person.GetComponent<Person>().doorDirection == true)
        {
            switch (isDoorOpen)
            {
                case true:
                    CloseDoor();
                    break;
                case false:
                    OpenDoor();
                    break;
            }
            /*if (!isDoorOpen)
            {
                OpenDoor();
            }
            else
            {
                
                    CloseDoor();
           
            }*/
        }
        else if (Person.GetComponent<Person>().doorDirection == false)
        {
            if (!isDoorOpen)
            {

                OpenDoor2();

            }
            else
            {

                CloseDoor2();

            }
        }
    }


    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor");
        isDoorOpen = true;
    }
    public void CloseDoor()
    {
        anim.SetTrigger("CloseDoor");
        isDoorOpen = false;
    }
    public void OpenDoor2()
    {
        anim.SetTrigger("OpenDoor2");
        isDoorOpen = true;
    }
    public void CloseDoor2()
    {
        anim.SetTrigger("CloseDoor2");
        isDoorOpen = false;
    }
    
}
