using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class MazeVisibility : NetworkBehaviour
{
    public void toggleWallVisibility()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        Debug.Log("2");
        GameObject wallList = GameObject.Find("Maze").transform.Find("Walls").gameObject;

        foreach (Transform wall in wallList.transform)
        {
            if (wall.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                wall.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (wall.gameObject.GetComponent<SpriteRenderer>().enabled == false)
            {
                wall.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

        }
    }

    public IEnumerator WallVisibilityCooldown()
    {
        toggleWallVisibility();
        yield return new WaitForSeconds(3.0f); 
        toggleWallVisibility();
    }

}
