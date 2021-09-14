using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class NextScene : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        if (isServer)
        {
            Scene scene = SceneManager.GetActiveScene();
            if ( scene.name == "MirrorLabManageTest") {
                NetworkManager.singleton.ServerChangeScene("Level 2");
            }

            else { 
                print("Level 2 finished!");
            }

        }
    }
}

