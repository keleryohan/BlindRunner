using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSpawner : NetworkBehaviour
{
    PlayerMovimentMP _playerMovement;
    MazeVisibility _mazeVisibility;
    GameStatus _gameStatus;
    public Vector3 _spawnPosition;
    private bool _firstSpawn = true;

    void Start()
    {
        _gameStatus = GameObject.FindObjectOfType<GameStatus>();
        _playerMovement = GetComponent<PlayerMovimentMP>();    
        _mazeVisibility = GetComponent<MazeVisibility>();    
        _spawnPosition = this.transform.position;
    }

    void Update()
    {
        if((_gameStatus.gameStarted && !_firstSpawn) || !_gameStatus.gameStarted) { return; }

        SpawnPlayer();
        _firstSpawn = false;
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
