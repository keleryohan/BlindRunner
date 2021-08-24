using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishBehavior : MonoBehaviour
{
    [SerializeField] Text _victoryText;

    private void OnTriggerEnter2D(Collider2D col)
    {
        string winWorlds = col.gameObject.tag + " Venceu!!!";
        _victoryText.text = winWorlds;
        Debug.Log(winWorlds);
    }
}
