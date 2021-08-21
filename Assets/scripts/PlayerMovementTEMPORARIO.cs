using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTEMPORARIO : MonoBehaviour
{
    public float speed = 10.0f;

    // Script rapido só pra testes
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput =  Input.GetAxis("Vertical");
        
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
