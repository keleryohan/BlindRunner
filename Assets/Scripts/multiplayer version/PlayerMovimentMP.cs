using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovimentMP : NetworkBehaviour
{
    public float speed = 10.0f;
    public string horizontal = "Horizontal";
    public string vertical = "Vertical";
    public bool _isFreeze = false;

    void Update()
    {
        if (!isLocalPlayer)
        {
            // make non-local players run this
            return;
        }
        if(!_isFreeze)
        {
            float horizontalInput = Input.GetAxis(horizontal);
            float verticalInput = Input.GetAxis(vertical);

            transform.position += new Vector3(horizontalInput, verticalInput, transform.position.z) * Time.deltaTime * speed;
        }
    }

    //player entrar no server
    public override void OnStartLocalPlayer()
    {
        if (isLocalPlayer)
        {
            FreezePlayer();    
        }
        
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 0, -5);
    }

    public IEnumerator FreezePlayer()
    {
        _isFreeze = true;
        yield return new WaitForSeconds(3.0f); 
        _isFreeze = false;
    }

}
