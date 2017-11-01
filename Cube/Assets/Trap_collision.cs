using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        print("Onparticlecollision");
        
    }
}
