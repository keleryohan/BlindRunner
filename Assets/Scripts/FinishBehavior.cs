using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishBehavior : MonoBehaviour
{
    [SerializeField] Text _victoryText;

    private void OnTriggerEnter2D(Collider2D col)
    {
        string winWorlds = col.gameObject.tag + " Venceu!!!";
        _victoryText.text = winWorlds;
        Debug.Log(winWorlds);
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
