using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndingBehaviour : MonoBehaviour
{
    int endingId = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("1"))
        {
            endingId = 1;
        }
        if (gameObject.name.Contains("2"))
        {
            endingId = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerIdScript>().playerId == endingId)
            {
                print("finished");
            }
        }
    }
}
