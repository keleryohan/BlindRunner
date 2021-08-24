using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehavior : MonoBehaviour
{
    
    Vector2 respawnPoint = Vector2.zero;


    public void PlayerCollidedWall(GameObject player)
    {
        player.transform.position = respawnPoint;
    }
}
