using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector3 initialWorldPos;
    [Range(1.0f, 10.0f)] public float speed = 1.0f;
    public Weapon weapon;

    private Transform _transform;
    private Transform _weaponTransform;
    private float _axisMoveInputX = 0.0f;
    private float _axisMoveInputY = 0.0f;
    private float _axisAimInputX = 0.0f;
    private float _axisAimInputY = 0.0f;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _aimDirection = Vector3.zero;
    private Vector3 _currentWorldPos = Vector3.zero;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _transform.position = initialWorldPos;
        _currentWorldPos = initialWorldPos;
        _weaponTransform = weapon.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        GetAxisInput();
        Move();
        Aim();
    }

    private void Aim()
    {
        if (_aimDirection.magnitude > 0.7f)
            _weaponTransform.LookAt(_aimDirection + _weaponTransform.position);
    }

    private void Move()
    {
        _currentWorldPos = _transform.position;
        _currentWorldPos.x += _moveDirection.x * Time.deltaTime * speed;
        _currentWorldPos.z += _moveDirection.z * Time.deltaTime * speed;

        _transform.position = _currentWorldPos;
    }
    /// <summary>
	/// Get Axis data of the joysick
	/// </summary>
	private void GetAxisInput()
    {
        _moveDirection.x = 0.0f;
        _moveDirection.z = 0.0f;
        _aimDirection.x = 0.0f;
        _aimDirection.z = 0.0f;

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

        _axisAimInputX = Input.GetAxisRaw("Horizontal-RS");
        _aimDirection.x = _axisAimInputX;

        _axisAimInputY = Input.GetAxisRaw("Vertical-RS");
        _aimDirection.z = _axisAimInputY;

        _moveDirection.Normalize();
    }
}
