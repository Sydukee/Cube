using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

    private string[] identity;
    private bool isAlive;
    private bool isClimbing = false;
    private float climbY;


    public float climbSpeed = 2.0f;
    public bool doorDirection = true;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
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
        if(other.tag == Tags.ladder && Input.GetKeyDown(KeyCode.F))
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
    public void Climb()
    {
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


    public bool getIsAlive()
    {
        return isAlive;
    }
    public void setIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

}
