using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public ParticleSystem[] traps;



	
    public void Trap_Start()
    {
        foreach(ParticleSystem ps in traps)
        {
            ps.Play();
        }
    }
    public void Trap_Stop()
    {
        foreach(ParticleSystem ps in traps)
        {
            ps.Stop();
        }
    }
}
