using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Net : NetworkManager
{

    private string ipAddress;
    public int chosenCharacter = 0;
    public int[] savedCharacter ;
    private int RandomCharacter;
    private bool hasBeenSaved = true;
    private int index = 0;


    //subclass for sending network messages
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }

    public void Start()
    {
        savedCharacter = new int[5] { 0, 0, 0, 0, 0 };
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        do
        {
            RandomCharacter = Random.Range(1, 6);
            foreach (int i in savedCharacter)
            {
                if (i == RandomCharacter)
                {
                    hasBeenSaved = true;
                    break;
                }
                else
                {
                    hasBeenSaved = false;
                }
            }
        }
        while (hasBeenSaved);
        savedCharacter[index] = RandomCharacter;
        index++;
        hasBeenSaved = true;
        chosenCharacter = RandomCharacter - 1;

        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = chosenCharacter;
        Debug.Log("server add with message " + selectedClass);


        if (selectedClass == 0)
        {
            GameObject player = Instantiate(Resources.Load("Player_Killer")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 1)
        {
            GameObject player = Instantiate(Resources.Load("Player_Police")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 2)
        {
            GameObject player = Instantiate(Resources.Load("Player_MathStudent")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 3)
        {
            GameObject player = Instantiate(Resources.Load("Player_Idiot")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 4)
        {
            GameObject player = Instantiate(Resources.Load("Player_Civilian")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
    }


    public override void OnClientConnect(NetworkConnection conn)
    {
        
        
       

        NetworkMessage test = new NetworkMessage();
        test.chosenClass = chosenCharacter;


        ClientScene.AddPlayer(conn, 0, test);
        
    }




    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        //base.OnClientSceneChanged(conn);
    }


    public void btn0()
    {
        chosenCharacter = 0;
    }


    public void btn1()
    {
        chosenCharacter = 1;
    }

    public void btn2()
    {
        chosenCharacter = 2;
    }

    public void btn3()
    {
        chosenCharacter = 3;
    }

    public void btn4()
    {
        chosenCharacter = 4;
    }
}