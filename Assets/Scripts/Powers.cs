using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    [SerializeField] GameObject _oponentPlayer;
    [SerializeField] KeyCode _power1;
    [SerializeField] KeyCode _power2;

    [SerializeField] float _powerCoolDown = 5.0f;

    private bool _isPowerActive = false;

    void Update()
    {
        if(!_isPowerActive)
        {
            if(Input.GetKey(_power1))
            {
                StartCoroutine(Slow());
                string mensagem = "Power 1 ativado no " + this.gameObject.tag + " contra o " + _oponentPlayer.gameObject.tag;
                Debug.Log(mensagem);

            }
            else if(Input.GetKey(_power2))
            {
                StartCoroutine(Freeze());
                string mensagem2 = "Power 2 ativado no " + this.gameObject.tag + " contra o " + _oponentPlayer.gameObject.tag;
                Debug.Log(mensagem2);
            }
        }
    }

    private IEnumerator Slow()
    {
        _isPowerActive = true;
        Color spritecolor = _oponentPlayer.GetComponent<SpriteRenderer>().color;
        _oponentPlayer.GetComponent<PlayerMovementTEMPORARIO>().speed = 1.0f;
        _oponentPlayer.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(_powerCoolDown); 

        _oponentPlayer.GetComponent<PlayerMovementTEMPORARIO>().speed = 10.0f;
        _oponentPlayer.GetComponent<SpriteRenderer>().color = spritecolor;
        _isPowerActive = false;
    }

    private IEnumerator Freeze()
    {
        _isPowerActive = true;
        Color spritecolor = _oponentPlayer.GetComponent<SpriteRenderer>().color;
        _oponentPlayer.GetComponent<PlayerMovementTEMPORARIO>().speed = 0f;
        _oponentPlayer.GetComponent<SpriteRenderer>().color = Color.blue;

        yield return new WaitForSeconds(_powerCoolDown); 

        _oponentPlayer.GetComponent<PlayerMovementTEMPORARIO>().speed = 10.0f;
        _oponentPlayer.GetComponent<SpriteRenderer>().color = spritecolor;
        _isPowerActive = false;
    }
}
