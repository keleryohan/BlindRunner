using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerPowers : NetworkBehaviour
{
    PlayerMovimentMP _playerMovement;
    [SyncVar(hook = "setColor")]
    private Color color = Color.white;   

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovimentMP>();
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetButtonDown("Power1"))
            {
                CmdChangeColor(255, 0, 0);
                StartCoroutine(_playerMovement.FreezePlayer());
                
            }

            if (Input.GetButtonDown("Power2"))
            {
                CmdChangeColor(0, 255, 0);
                StartCoroutine(_playerMovement.SlowPlayer());
            }

            if (Input.GetButtonDown("Power3"))
            {
                CmdChangeColor(0, 0, 255);
                StartCoroutine(_playerMovement.FastPlayer());
            }
        }
    }

    private void setColor(Color old, Color c)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = c;
    }

    [Command]
    public void CmdChangeColor(float r, float g, float b)
    {
        this.color = new Color(r, g, b);
    }
}