using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviourScript : MonoBehaviour
{
    public MovementType movementType;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public bool decay;
    public bool snap;
    public float horizontalStep;
    public float verticalStep;

    private float _horizontalAxis = 0;
    private float _verticalAxis = 0;
    private Rigidbody2D _rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            _horizontalAxis += horizontalStep * Time.deltaTime;
        }
        if (Input.GetKey(downKey))
        {
            _horizontalAxis -= horizontalStep * Time.deltaTime;
        }
        if (Input.GetKey(rightKey))
        {
            _verticalAxis += verticalStep * Time.deltaTime;
        }
        if (Input.GetKey(leftKey))
        {
            _verticalAxis -= verticalStep * Time.deltaTime;
        }
        _horizontalAxis = ClampMagnitude(_horizontalAxis, 1);
        _verticalAxis = ClampMagnitude(_verticalAxis, 1);

        if (decay)
        {
            _horizontalAxis *= Time.deltaTime * 10;
            _verticalAxis *= Time.deltaTime * 10;
        }

        if (snap)
        {
            _horizontalAxis = ClampMagnitude(_horizontalAxis, 0.1f);
            _verticalAxis = ClampMagnitude(_verticalAxis, 0.1f);
        }

        _rigid2D.AddForce(Vector2.up * _horizontalAxis*10);
        _rigid2D.AddForce(Vector2.right * _verticalAxis*10);
    }

    float Snap(float value,float magnitude)
    {
        if (value > 0)
        {
            if (value > magnitude)
            {
                return value;
            }
        }
        else if (-value > magnitude)
        {

            return value;

        }
        return 0;
    }

    float ClampMagnitude(float value,float magnitude)
    {
        if (value > 0)
        {
            if (value > magnitude)
            {
                return magnitude;
            }
        }
        else if (-value > magnitude) { 
            
            return -magnitude;
            
        }
        return value;
    }
}

public enum MovementType
{
    Car,
    Static,
    StaticGravity
}