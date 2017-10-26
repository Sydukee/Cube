using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    private string[] Identity = { "Killer", "Police", "MathStudent", "Idiot", "Civilian" };
    private int IdentityIndex;

    public override void OnStartClient()
    {
        print(123);
    }
}
