using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{
    public GameObject PlayerPrefab;

    public string playerName;
    
    void Start()
    {
        // Is this actually my local player object?

        // since the player object is invisible, give me something physical to move around
        Instantiate(PlayerPrefab);
    }



    void Update()
    {
        
    }
}
