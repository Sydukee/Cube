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

    public int[] savedCharacter_2;
    private int RandomCharacter_2;
    private bool hasBeenSaved_2 = true;
    private int index_2 = 0;


    //subclass for sending network messages
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }

    public void Start()
    {
        savedCharacter = new int[5] { 0, 0, 0, 0, 0 };
        savedCharacter_2 = new int[5] { 0, 0, 0, 0, 0 };
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


        do
        {
            RandomCharacter_2 = Random.Range(1, 6);
            foreach (int i in savedCharacter_2)
            {
                if (i == RandomCharacter_2)
                {
                    hasBeenSaved_2 = true;
                    break;
                }
                else
                {
                    hasBeenSaved_2 = false;
                }
            }
        }
        while (hasBeenSaved_2);
        savedCharacter_2[index_2] = RandomCharacter_2;
        index_2++;
        hasBeenSaved_2 = true;


        chosenCharacter = (RandomCharacter_2 - 1) * 5 + (RandomCharacter - 1);


        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = chosenCharacter;
        Debug.Log("server add with message " + selectedClass);


        if (selectedClass == 0)
        {
            GameObject player = Instantiate(Resources.Load("Player_Killer_1")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 1)
        {
            GameObject player = Instantiate(Resources.Load("Player_Police_1")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 2)
        {
            GameObject player = Instantiate(Resources.Load("Player_MathStudent_1")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 3)
        {
            GameObject player = Instantiate(Resources.Load("Player_Idiot_1")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 4)
        {
            GameObject player = Instantiate(Resources.Load("Player_Civilian_1")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 5)
        {
            GameObject player = Instantiate(Resources.Load("Player_Killer_2")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 6)
        {
            GameObject player = Instantiate(Resources.Load("Player_Police_2")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 7)
        {
            GameObject player = Instantiate(Resources.Load("Player_MathStudent_2")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 8)
        {
            GameObject player = Instantiate(Resources.Load("Player_Idiot_2")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 9)
        {
            GameObject player = Instantiate(Resources.Load("Player_Civilian_2")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 10)
        {
            GameObject player = Instantiate(Resources.Load("Player_Killer_3")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 11)
        {
            GameObject player = Instantiate(Resources.Load("Player_Police_3")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 12)
        {
            GameObject player = Instantiate(Resources.Load("Player_MathStudent_3")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 13)
        {
            GameObject player = Instantiate(Resources.Load("Player_Idiot_3")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 14)
        {
            GameObject player = Instantiate(Resources.Load("Player_Civilian_3")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 15)
        {
            GameObject player = Instantiate(Resources.Load("Player_Killer_4")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 16)
        {
            GameObject player = Instantiate(Resources.Load("Player_Police_4")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 17)
        {
            GameObject player = Instantiate(Resources.Load("Player_MathStudent_4")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 18)
        {
            GameObject player = Instantiate(Resources.Load("Player_Idiot_4")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 19)
        {
            GameObject player = Instantiate(Resources.Load("Player_Civilian_4")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 20)
        {
            GameObject player = Instantiate(Resources.Load("Player_Killer_5")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 21)
        {
            GameObject player = Instantiate(Resources.Load("Player_Police_5")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 22)
        {
            GameObject player = Instantiate(Resources.Load("Player_MathStudent_5")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 23)
        {
            GameObject player = Instantiate(Resources.Load("Player_Idiot_5")) as GameObject;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (selectedClass == 24)
        {
            GameObject player = Instantiate(Resources.Load("Player_Civilian_5")) as GameObject;
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


    
}