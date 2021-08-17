using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehavior : MonoBehaviour
{
    //todo: definir spawn points ao início da fase
    Vector2 respawnPoint = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCollidedWall(GameObject player)
    {
        player.transform.position = respawnPoint;
    }
}
