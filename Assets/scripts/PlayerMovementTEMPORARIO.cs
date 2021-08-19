using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTEMPORARIO : MonoBehaviour
{
    
    // Script rapido só pra testes
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput =  Input.GetAxis("Vertical");
        
        transform.position += new Vector3(horizontalInput, verticalInput, transform.position.z) * Time.deltaTime * 10.0f;
    }
}
