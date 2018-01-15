using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casing : MonoBehaviour {

    public GameObject casingMesh;
    public Vector3 casingOriginalOrientation = new Vector3(0.0f, 0.0f, 90.0f);
    public float rotateStrenght = 1000.0f;
    public float casingLifeTime = 3.0f;

    private Quaternion _casingOriginalOrientationQ;
    private Transform _casingMeshTransform;
    private Rigidbody _rigidbody;

	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.detectCollisions = false;

        _casingOriginalOrientationQ = Quaternion.Euler(casingOriginalOrientation);
        _casingMeshTransform = casingMesh.GetComponent<Transform>();
        rotateStrenght += Random.Range(-200.0f, 200.0f);

        Invoke("DestroyCasing", casingLifeTime);
    }
	

	void Update ()
    {
        _casingMeshTransform.Rotate(Vector3.one * Time.deltaTime * rotateStrenght, Space.World);
    }

    private void DestroyCasing()
    {
        Destroy(this.gameObject);
    }

    public void HandleCasingPhysics()
    {

    }
}
