using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

    private string[] identity;
    private bool isAlive;
    private float moveSpeed = 1.0f;
    private CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        cc.Move(new Vector3(x, 0, y)*moveSpeed);
    }



    public bool getIsAlive()
    {
        return isAlive;
    }
    public void setIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public void setMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
}
