using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Vector3 initialWorldPos;
    [Range(1.0f, 10.0f)] public float speed = 1.0f;

    private Transform _transform;
    private float _axisMoveInputX = 0.0f;
    private float _axisMoveInputY = 0.0f;
    private float _axisAimInputX = 0.0f;
    private float _axisAimInputY = 0.0f;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _currentWorldPos = Vector3.zero;

    void Start () {
        _transform = GetComponent<Transform>();
        _transform.position = initialWorldPos;
        _currentWorldPos = initialWorldPos;
    }
	
	void FixedUpdate () {
        getAxisInput();
        move();
    }

    private void move()
    {
        _currentWorldPos = _transform.position;
        _currentWorldPos.x += _moveDirection.x * Time.deltaTime * speed;
        _currentWorldPos.z += _moveDirection.z * Time.deltaTime * speed;

        _transform.position = _currentWorldPos;
    }
    /// <summary>
	/// Get Axis data of the joysick
	/// </summary>
	private void getAxisInput()
    {
        _moveDirection.x = 0.0f;
        _moveDirection.z = 0.0f;
        if (Input.GetAxisRaw("Horizontal-LS") > 0.3 || Input.GetAxisRaw("Horizontal-LS") < -0.3)
        {
            _axisMoveInputX = Input.GetAxisRaw("Horizontal-LS");
            _moveDirection.x = _axisMoveInputX;
        }

        if (Input.GetAxisRaw("Vertical-LS") > 0.3 || Input.GetAxisRaw("Vertical-LS") < -0.3)
        {
            _axisMoveInputY = Input.GetAxisRaw("Vertical-LS");
            _moveDirection.z = _axisMoveInputY;
        }

        if (Input.GetAxisRaw("Horizontal-RS") > 0.3 || Input.GetAxisRaw("Horizontal-RS") < -0.3)
        {
            _axisAimInputX = Input.GetAxisRaw("Horizontal-RS");
        }

        if (Input.GetAxisRaw("Vertical-RS") > 0.3 || Input.GetAxisRaw("Vertical-RS") < -0.3)
        {
            _axisAimInputY = Input.GetAxisRaw("Vertical-RS");
        }

        _moveDirection.Normalize();
    }

    

    /// <summary>
    /// show the data onGUI
    /// </summary>
    /*void OnGUI()
    {
        GUI.TextArea(new Rect(400, 200, 250, 50), "Current Axis : " + currentAxis);
        GUI.TextArea(new Rect(400, 300, 250, 50), "Axis Value : " + axisInput);
    }*/
}
