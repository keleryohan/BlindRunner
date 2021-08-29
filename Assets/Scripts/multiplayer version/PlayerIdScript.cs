using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerIdScript : NetworkBehaviour
{
    private PlayerManager playerManager;

    public int playerId = 0;

    private void Awake()
    {
        //todo: substituir por referencia
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
    }

    public override void OnStartLocalPlayer()
    {
        playerId = playerManager.playerCount;
        
        increaseId();

    }

    

    [Command]
    void increaseId()
    {
        playerManager.playerCount++;
        
    }



}
