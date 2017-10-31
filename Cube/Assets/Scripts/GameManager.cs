using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    public GameObject[] players;
    public GameObject[] lights;
    public GameObject Killer;
    public GameObject Police;
    public GameObject Idiot;
    public GameObject MathStudent;
    public GameObject Civilian;
    private bool Killer_alive;
    private bool Police_alive;
    private bool Idiot_alive;
    private bool MathStudent_alive;
    private bool Civilian_alive;
    public bool isOut;
    public bool gameStart = false;
    private float nexttime = 1;
    public int lightOffCd = 30;

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag(Tags.person);
        lights = GameObject.FindGameObjectsWithTag(Tags.ligt);
        GetPlayers();
        if (gameStart)
        {
            GetPlayers_Alive();
            LightOff();
        }
        
        if(players.Length == 5)
        {
            //Start Game
            gameStart = true;
            
        }
        if (!Police_alive && !MathStudent_alive && !Idiot_alive && !Civilian_alive)
        {
            //Killer win
        }
        if (!Police_alive && !MathStudent_alive && !Idiot_alive && !Civilian_alive && !Killer_alive)
        {
            //All lose
        }
        if (isOut)
        {
            //People win
        }

        

    }


    private void LightOff()
    {
        if (nexttime< Time.time)
        {
            lightOffCd--;
            nexttime = Time.time + 1;
        }
        
        if (lightOffCd > 0 && lightOffCd < 20)
        {
            //lightoff
            foreach(GameObject l in lights)
            {
                l.GetComponent<Light>().enabled = false;
            }
            print("lightoff");
        }
        if(lightOffCd <= 0)
        {
            //lighton
            foreach (GameObject l in lights)
            {
                l.GetComponent<Light>().enabled = true;
            }
            print("lighton");
            lightOffCd = 30;
        }
    }
    
    private void GetPlayers()
    {
        if (Killer == null)
        {
            foreach (GameObject p in players)
            {
                if (p.GetComponentInChildren<Killer>())
                {
                    Killer = p;
                }
            }
        }
        if (Police == null)
        {
            foreach (GameObject p in players)
            {
                if (p.GetComponentInChildren<Police>())
                {
                    Police = p;
                }
            }
        }
        if (Idiot == null)
        {
            foreach (GameObject p in players)
            {
                if (p.GetComponentInChildren<Idiot>())
                {
                    Idiot = p;
                }
            }
        }
        if (MathStudent == null)
        {
            foreach (GameObject p in players)
            {
                if (p.GetComponentInChildren<MathStudent>())
                {
                    MathStudent = p;
                }
            }
        }
        if (Civilian == null)
        {
            foreach (GameObject p in players)
            {
                if (p.GetComponentInChildren<Civilian>())
                {
                    Civilian = p;
                }
            }
        }
    }
    private void GetPlayers_Alive()
    {
        Killer_alive = Killer.GetComponent<Person>().getIsAlive();
        Police_alive = Police.GetComponent<Person>().getIsAlive();
        Idiot_alive = Idiot.GetComponent<Person>().getIsAlive();
        MathStudent_alive = MathStudent.GetComponent<Person>().getIsAlive();
        Civilian_alive = Civilian.GetComponent<Person>().getIsAlive();
    }

}
