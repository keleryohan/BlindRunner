using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        string WinWorlds = col.gameObject.tag + " Venceu!!!";
        Debug.Log(WinWorlds);
    }
}
