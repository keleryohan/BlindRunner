using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerNameScript : NetworkBehaviour
{
    public TextMesh playerNameText;

    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    public override void OnStartLocalPlayer()
    {
        string name;
        try
        {
            name = GameObject.Find("SceneManager").GetComponent<SceneManagerMP>().auxPlayerName;
        }
        catch
        {
            name = "Player" + Random.Range(100, 999);
        }
        if (name == null || name == "")
        {
            name = "Player" + Random.Range(100, 999);
        }
        CmdSetupPlayer(name);
    }

    [Command]
    public void CmdSetupPlayer(string _name)
    {
        playerName = _name;
    }

    void OnNameChanged(string _Old, string _New)
    {
        playerNameText.text = playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
