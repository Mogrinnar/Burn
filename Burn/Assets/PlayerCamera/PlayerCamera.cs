using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Player player;

    private Transform _transform;
    private Transform _playerTransform;
    private Vector3 _moveDirection = Vector3.zero;

    void Start () {
        _transform = GetComponent<Transform>();
        _playerTransform = player.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        _moveDirection = _transform.position;
        _moveDirection.x = _playerTransform.position.x;
        _moveDirection.z = _playerTransform.position.z;
        _transform.position = _moveDirection;
    }
}
