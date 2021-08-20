using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    RespawnBehavior respawnBehavior;

    MazeManager _mazeManager;
    
    [SerializeField] int playerId = 1;
    
    void Start()
    {
        //respawnBehavior = GameObject.Find("ScriptHolder").GetComponent<RespawnBehavior>();
        _mazeManager = GameObject.Find("MazeManager").GetComponent<MazeManager>();
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
          //  respawnBehavior.PlayerCollidedWall(gameObject);
            _mazeManager.RespawnPlayer(playerId);
        }
    }
}
