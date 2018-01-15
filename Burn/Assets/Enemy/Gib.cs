using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gib : MonoBehaviour {

    public GameObject gibMesh;
    public Vector3 gibOriginalOrientation = new Vector3(0.0f, 0.0f, 90.0f);
    public float gibLifeTime = 2.0f;
    public float rotateStrenght = 1000.0f;

    private Collider _gibCollider;
    private Quaternion _gibOriginalOrientationQ;
    private Transform _casingMeshTransform;

    void Start () {
        _gibOriginalOrientationQ = Quaternion.Euler(gibOriginalOrientation);
        _casingMeshTransform = gibMesh.GetComponent<Transform>();
        _gibCollider = gibMesh.GetComponent<Collider>();
        _gibCollider.enabled = false;
        rotateStrenght += Random.Range(-200.0f, 200.0f);

        Invoke("EnableCollider", 1.0f);
        Invoke("DestroyGib", gibLifeTime);
    }

	void Update () {
        _casingMeshTransform.Rotate(Vector3.one * Time.deltaTime * rotateStrenght, Space.World);
    }

    private void EnableCollider()
    {
        _gibCollider.enabled = true;
    }

    private void DestroyGib()
    {
        Destroy(this.gameObject);
    }
}
