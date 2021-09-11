using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCollisions : NetworkBehaviour
{
    PlayerSpawner _playerSpawner;

    void Start()
    {
        _playerSpawner = GetComponent<PlayerSpawner>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Wall"))
        {
            _playerSpawner.SpawnPlayer();
        }
    }

}
