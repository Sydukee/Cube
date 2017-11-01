using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour {

    private Animator anim;
    public bool isUp;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeState()
    {

       if(isUp == false)
        {
            anim.SetBool("GoUp", true);
            isUp = true;
        }
       else if(isUp == true)
        {
            anim.SetBool("GoUp", false);
            isUp = false;
        }
    }
}
