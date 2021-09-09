using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
    public float speed = 10.0f;
    public string horizontal = "Horizontal";
    public string vertical = "Vertical";
    public TextMesh playerNameText;
    public GameObject floatingInfo;

    private Material playerMaterialClone;

    //quando o server altera o valor da SyncVar, será chamado a função 'OnNameChanged'. 
    //e por ser uma SyncVar, o valor dela será atualizado em todos os clientes
    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;

    [SyncVar(hook = nameof(OnColorChanged))]
    public Color playerColor = Color.white;

    private SceneScript sceneScript;

    void Awake()
    {
        //allow all players to run this
        //sceneScript = GameObject.FindObjectOfType<SceneScript>();

        sceneScript = GameObject.Find("SceneReference").GetComponent<SceneReference>().sceneScript;
    }

     void OnNameChanged(string _Old, string _New)
    {
        playerNameText.text = playerName;
    }

    void OnColorChanged(Color _Old, Color _New)
    {
        playerNameText.color = _New;
        playerMaterialClone = new Material(GetComponent<Renderer>().material);
        playerMaterialClone.color = _New;
        GetComponent<Renderer>().material = playerMaterialClone;
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 0, -5);

        string name = "Player" + Random.Range(100, 999);
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        CmdSetupPlayer(name, color);

        sceneScript.playerScript = this;
    }

    [Command] //obs: Commands são funções chamadas no cliente, mas executadas no servidor
    //definindo nome e cor do player para o server/demais players
    public void CmdSetupPlayer(string _name, Color _col)
    {
        // player info sent to server, then server updates sync vars which handles it on all clients
        playerName = _name;
        playerColor = _col;
        sceneScript.statusText = $"{playerName} joined.";
    }

    [Command]
    public void CmdSendPlayerMessage()
    {
        if (sceneScript)
        {
            sceneScript.statusText = $"{playerName} says hello {Random.Range(10, 99)}";
        }
    }



    // Update is called once per frame
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SpeedPower"))
        {
            speed = 20.0f;
            Destroy(other.gameObject);
        }
    }
}
