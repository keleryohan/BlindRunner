using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class GameStatus : NetworkBehaviour
{
    PlayerManager playerManager;
    
    [SyncVar]
    public bool gameStarted = false;

    // Start is called before the first frame update

    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkGameStatus()
    {
        //print("check - " + playerManager.playerCount);
        if(playerManager.playerCount == 2)
        {
            gameStarted = true;
            //print("game starting - " + playerManager.playerCount + " - " + gameStarted);
        }
    }
}
