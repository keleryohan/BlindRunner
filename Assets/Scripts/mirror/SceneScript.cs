using Mirror;
using UnityEngine;
using UnityEngine.UI;


    public class SceneScript : NetworkBehaviour
    {
        public Text canvasStatusText;
        public PlayerScript playerScript; //o playerScript vai acessar essa variável e se colocar nela

        //variável para auxiliar o playerscript encontrar o scene script 
        public SceneReference sceneReference;

        [SyncVar(hook = nameof(OnStatusTextChanged))]
        public string statusText;

        void OnStatusTextChanged(string _Old, string _New)
        {
            //called from sync var hook, to update info on screen for all players
            canvasStatusText.text = statusText;
        }

        public void ButtonSendMessage()
        {
            if (playerScript != null)
            {
                playerScript.CmdSendPlayerMessage();
            }
        }
    }
