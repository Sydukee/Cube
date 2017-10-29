using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Killer : NetworkBehaviour {

    public GameObject KillText;
    public GameObject E_Button;
    public NetworkIdentity PlayerNetID;
    public GameObject CdTimer;
    private float KillCd = 0;
    private float nextTime = 1;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (KillText == null)
        {
            KillText = GameObject.Find("KillText");
        }
        if (E_Button == null)
        {
            E_Button = GameObject.Find("E_Button");
        }
        if(CdTimer == null)
        {
            CdTimer = GameObject.Find("KillTimer");
        }
        if (KillCd > 0)
        {
            CdTimer.GetComponent<Text>().enabled = true;
            KillText.GetComponent<Text>().enabled = false;
            E_Button.GetComponent<Image>().enabled = false;
            Timer1();
        }
        else
        {
            CdTimer.GetComponent<Text>().enabled = false;

        }
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (!PlayerNetID.isLocalPlayer)
        {
            return;
        }
        
        if(other.tag == Tags.person)
        {
            print(other.GetComponentInChildren<Police>());
            if (other.GetComponentInChildren<Police>() == null && KillCd == 0)
            {
                KillText.GetComponent<Text>().enabled = true;
                E_Button.GetComponent<Image>().enabled = true;
                //kill
                if (Input.GetKeyDown(KeyCode.E))
                {

                    other.GetComponent<Person>().die();
                    KillCd = 300;
                }
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
            KillText.GetComponent<Text>().enabled = false;
            E_Button.GetComponent<Image>().enabled = false;
        }
    }
    private void Timer1()
    {
        if (nextTime <= Time.time)
        {
            KillCd--;//second为倒计时时间
            CdTimer.GetComponent<Text>().text = "冷却中"+KillCd.ToString()+"s";
            nextTime = Time.time + 1;//到达一秒后加1
          
        }
    }
}
