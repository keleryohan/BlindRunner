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
    GameStatus gameStatus;

    private void Start()
    {
        gameStatus = GameObject.FindObjectOfType<GameStatus>();
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            // make non-local players run this
            return;
        }
        //n�o disponibilize controles sem o jogo ter come�ado
        if (!gameStatus.gameStarted)
        {
            return;
        }
        if (!_isFreeze)
        {
            float horizontalInput = Input.GetAxis(horizontal);
            float verticalInput = Input.GetAxis(vertical);

            transform.position += new Vector3(horizontalInput, verticalInput, transform.position.z) * Time.deltaTime * speed;
        }
    }

    //player entrar no server
    public override void OnStartLocalPlayer()
    {
        /*
        if (isLocalPlayer)
        {
            FreezePlayer();    
        }
        */
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 0, -5);
    }
    
    public IEnumerator FreezePlayer()
    {
        speed = 0f;
        yield return new WaitForSeconds(3.0f);
        speed = 10f;
    }

    public IEnumerator SlowPlayer()
    {
        speed = 1f;
        yield return new WaitForSeconds(3.0f);
        speed = 10f;
    }

    public IEnumerator FastPlayer()
    {
        speed= 50f;
        yield return new WaitForSeconds(3.0f);
        speed = 10f;
    }
}

