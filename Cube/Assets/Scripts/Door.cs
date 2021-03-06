﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Animator anim;
    private string openDoor = "OpenDoor";
    private string closeDoor = "CloseDoor";
    private bool isDoorOpen = false;

    public GameObject Person;

	
	void Start () {
        anim = this.GetComponent<Animator>();
        Person = GameObject.FindGameObjectWithTag("Player");
	}
	
	
    public void ChangeDoorState()
    {
        if (Person.GetComponent<Person>().doorDirection == true)
        {
            if (!isDoorOpen)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
        }
        if (Person.GetComponent<Person>().doorDirection == false)
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
