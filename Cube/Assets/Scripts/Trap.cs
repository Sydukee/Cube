using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public ParticleSystem[] traps;
    public GameObject[] move_walls;
    public GameObject[] doors;
    public GameObject lightning;
    public bool Trap_CloseDoor = false;
    private float Timer = 0;

    private void Update()
    {
        
    }

    public void Trap_Start()
    {
        if (traps != null)
        {
            foreach (ParticleSystem ps in traps)
            {
                ps.Play();
            }
        }
        if (move_walls != null)
        {
            foreach(GameObject mw in move_walls)
            {
                mw.GetComponent<MoveWall>().ChangeState();
            }
            foreach(GameObject d in doors)
            {
                d.GetComponent<Door>().enabled = false;
            }
        }
        if(lightning != null)
        {
            lightning.GetComponent<MoveLightning_Start>().PlayAnim();
        }
        if (Trap_CloseDoor)
        {
            foreach(GameObject d in doors)
            {
                if (d.GetComponent<Door>().isDoorOpen == true)
                {
                    d.GetComponent<Door>().ChangeDoorState();
                    d.GetComponent<Door>().enabled = false;
                }
            }
        }
    }
    public void Trap_Stop()
    {
        if (traps != null)
        {
            foreach (ParticleSystem ps in traps)
            {
                ps.Stop();
            }
        }

    }
}
