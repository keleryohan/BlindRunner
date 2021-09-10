using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{

    [SyncVar]
    public int playerCount;

    private void Awake()
    {
        playerCount = 1;
    }

}
