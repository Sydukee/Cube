using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Person : NetworkBehaviour {

    private string[] identity;
    private bool isAlive;
    private bool isClimbing = false;
    private float climbY;
    private bool isButtonDown = false;

    public float climbSpeed = 2.0f;
    public bool doorDirection = true;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        if (isClimbing)
        {
            Climb();
            if (Input.GetKeyDown(KeyCode.G))
            {
                this.gameObject.GetComponent<PlayerMove>().enabled = true;
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
                rb.useGravity = true;
                isClimbing = false;
            }
            
        }
        
    }

    

   
    public void OnTriggerStay(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (other.tag == Tags.door3 && Input.GetKeyDown(KeyCode.E) && !isButtonDown)
        {
            CmdChangeDoor(other.gameObject);
            doorDirection = true;
            isButtonDown = true;


        }
        else if (other.tag == Tags.door3 && Input.GetKeyDown(KeyCode.E) && isButtonDown)
        {
            isButtonDown = false;
        }
        if (other.tag == Tags.door1 && Input.GetKeyDown(KeyCode.E))
        {
            CmdChangeDoor(other.gameObject);
            doorDirection = true;

        }
        if (other.tag == Tags.door2 && Input.GetKeyDown(KeyCode.E))
        {
            CmdChangeDoor(other.gameObject);
            doorDirection = false;

        }

        if (other.tag == Tags.ladder && Input.GetKeyDown(KeyCode.F))
        {
            if(other.name == "ClimbPoint1")
            {
                this.transform.position = other.transform.position + new Vector3(0, 0, 0.5f);
                isClimbing = true;
                climbY = other.transform.position.y;                
            }
            else if (other.name == "ClimbPoint2")
            {
                this.transform.position = other.transform.position + new Vector3(0, 0, -0.45f);
                isClimbing = true;
                climbY = other.transform.position.y;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (other.tag.Equals(Tags.trap))
        {
            other.gameObject.GetComponent<Trap>().Trap_Start();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (other.tag.Equals(Tags.trap))
        {
            other.gameObject.GetComponent<Trap>().Trap_Stop();
        }
    }
    public void Climb()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        this.gameObject.GetComponent<PlayerMove>().enabled = false;
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();       
        rb.useGravity = false;
        float y = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * y * climbSpeed);

        Vector3 tp = transform.position;
        if (tp.y <= climbY)
            transform.position = new Vector3(tp.x, climbY, tp.z);
        else if (tp.y >= climbY + 8.5f)
            transform.position = new Vector3(tp.x, climbY + 8.5f, tp.z);
        
    }

    [Command]
    public void CmdChangeDoor(GameObject g)
    {
        g.GetComponentInParent<Door>().RpcChangeDoorState();
    }


    public bool getIsAlive()
    {

        return isAlive;
    }
    public void setIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

    public void die()
    {
        setIsAlive(false);
    }
}
