using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLightning_Start : MonoBehaviour {

    public GameObject Trap_Lightning;
	
    public void PlayAnim()
    {
        Animator anim = Trap_Lightning.GetComponent<Animator>();
        anim.SetTrigger("LightningMove");
    }
}
