using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Idiot : NetworkBehaviour {

    public GameObject IdiotText;
    public GameObject E_Button;
    public NetworkIdentity PlayerNetID;
    public GameObject RoomPosText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IdiotText == null)
        {
            IdiotText = GameObject.Find("IdiotText");
        }
        if (E_Button == null)
        {
            E_Button = GameObject.Find("E_Button");
        }
        if(RoomPosText == null)
        {
            RoomPosText = GameObject.Find("RoomPosText");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!PlayerNetID.isLocalPlayer)
        {
            return;
        }

        if(other.tag == Tags.room&&IdiotText!=null)
        {
            IdiotText.GetComponent<Text>().enabled = true;
            E_Button.GetComponent<Image>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Vector3 roomPos = other.GetComponent<RoomInfo>().RoomPos;
                RoomPosText.GetComponent<Text>().enabled = true;
                RoomPosText.GetComponent<Text>().text = roomPos.ToString();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!PlayerNetID.isLocalPlayer)
        {
            return;
        }
        if (other.tag == Tags.person)
        {
            IdiotText.GetComponent<Text>().enabled = false;
            E_Button.GetComponent<Image>().enabled = false;
        }
    }
}
