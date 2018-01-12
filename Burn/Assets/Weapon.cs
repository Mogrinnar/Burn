using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public CasingGenerator casingGenerator;

    [Tooltip("Amount of time between shots")]
    public float shootingSpeed = 1.0f;
    private float _shootingDelta = -0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(_shootingDelta > 0.0f)
        {
            _shootingDelta -= Time.deltaTime;
        }

        var attack = Input.GetAxis("Fire1");
        if (attack < 0.0f && _shootingDelta < 0.0f)
        {
            _shootingDelta = shootingSpeed;

            //shoot
            casingGenerator.shootSpentCasing();
        }
    }
}
