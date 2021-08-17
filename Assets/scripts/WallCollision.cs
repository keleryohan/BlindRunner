using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    RespawnBehavior respawnBehavior;
    //se é player 1 ou 2
    //todo
    int playerId = 1;

    // Start is called before the first frame update
    void Start()
    {
        respawnBehavior = GameObject.Find("ScriptHolder").GetComponent<RespawnBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            respawnBehavior.PlayerCollidedWall(gameObject);
        }
    }
}
