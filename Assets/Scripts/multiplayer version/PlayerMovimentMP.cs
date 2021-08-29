using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovimentMP : NetworkBehaviour
{
    public float speed = 10.0f;
    public string horizontal = "Horizontal";
    public string vertical = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            // make non-local players run this
            return;
        }

        float horizontalInput = Input.GetAxis(horizontal);
        float verticalInput = Input.GetAxis(vertical);

        transform.position += new Vector3(horizontalInput, verticalInput, transform.position.z) * Time.deltaTime * speed;
    }

    //player entrar no server
    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 0, -5);

    }
    }
