using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    MazeManager _mazeManager;
    
    void Start()
    {
        _mazeManager = GameObject.Find("MazeManager").GetComponent<MazeManager>();
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            //_mazeManager.RespawnPlayer(playerId);
            _mazeManager.StartCoolDown(this.gameObject.tag);
        }
    }
}
