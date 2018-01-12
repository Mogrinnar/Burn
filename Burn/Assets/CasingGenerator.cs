using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingGenerator : MonoBehaviour {

    public Casing casingPrefab;
    
    public Vector3 casingDirection = new Vector3(-1.0f, 1.0f, -1.0f);
    public float ejectStrenght = 10.0f;
    public float minRandom = -0.3f;
    public float maxRandom = 0.3f;

    private Transform _transform;

    // Use this for initialization
    void Start () {
        _transform = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void shootSpentCasing()
    {
        var casing = Instantiate(casingPrefab, transform.parent.position, transform.parent.rotation, null);
        Rigidbody casingRigidBody = casing.GetComponent<Rigidbody>();

        var currentCasingDirection = new Vector3(casingDirection.x + Random.Range(minRandom, maxRandom), casingDirection.y + Random.Range(minRandom, maxRandom), casingDirection.z + Random.Range(minRandom, maxRandom));
        casingRigidBody.AddRelativeForce(casingDirection * (ejectStrenght + (Random.Range(minRandom, maxRandom) * ejectStrenght)), ForceMode.Impulse);

        casing.HandleCasingPhysics();
    }
}
