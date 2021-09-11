using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSpawner : NetworkBehaviour
{
    PlayerMovimentMP _playerMovement;
    MazeVisibility _mazeVisibility;
    public Vector3 _spawnPosition;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovimentMP>();    
        _mazeVisibility = GetComponent<MazeVisibility>();    
        _spawnPosition = this.transform.position;
    }

    public void SpawnPlayer()
    {
        if(isLocalPlayer)
        {
            this.transform.position = _spawnPosition;
            StartCoroutine(_playerMovement.FreezePlayer());
            StartCoroutine(_mazeVisibility.WallVisibilityCooldown());
        }
    }

    
}
