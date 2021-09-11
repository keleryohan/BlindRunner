using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerMP : MonoBehaviour
{
    //variável auxiliar para salvar o nome do player

    public string auxPlayerName = "";
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void StartGame()
    {
        auxPlayerName = GameObject.Find("NameInput").GetComponent<InputField>().text;
        //print(auxPlayerName);
        //nome da cena com a fase 1
        LoadScene("MirrorLabManageTest");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
