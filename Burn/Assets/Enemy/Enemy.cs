using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Range(0.1f, 1.0f)] public float speed = 0.1f;
    [Range(1, 10)] public int hitpoints = 1;
    public Color colorStart = Color.white;
    public Color colorEnd = Color.green;
    public Gib gibPrefab;

    [Tooltip("Amount of gib game objects spawned on death")]
    [Range(4, 16)] public int gibAmount = 4;

    private int _maxHitPoints;
    private Renderer _renderer;
    private GameObject _player;
    private Collider _collider;

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();
        _renderer.material.color = colorStart;
        _maxHitPoints = hitpoints;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    private void Move()
    {
        if (hitpoints <= 0)
            return;

        Vector3 distance = _player.transform.position - transform.position;
        distance.Normalize();
        distance *= speed;

        Vector3 move = transform.position + distance;
        transform.position = move;
    }

    private void createGibPrefabs ()
    {
        float scaleFactor = gibAmount / 2.0f; //to cache ?
        Vector3 gibPrefabLocalScale = gibPrefab.transform.localScale;
        gibPrefabLocalScale /= scaleFactor;

        shootGibPrefab(new Vector3(1.0f, 5.0f, 1.0f));
        shootGibPrefab(new Vector3(1.0f, 5.0f, -1.0f));
        shootGibPrefab(new Vector3(-1.0f, 5.0f, -1.0f));
        shootGibPrefab(new Vector3(-1.0f, 5.0f, 1.0f));
    }

    private void shootGibPrefab(Vector3 in_direction)
    {
        var gib = Instantiate(gibPrefab, transform.position, transform.rotation, null);
        Rigidbody gibRigidBody = gib.GetComponent<Rigidbody>();

        var gibDirection = in_direction;
        gibDirection.Normalize();
        gibDirection *= 10.0f;
        gibRigidBody.AddRelativeForce(gibDirection, ForceMode.Impulse);
    }

    public void Hit(int hitDamage = 1)
    {
        hitpoints -= hitDamage;

        if(hitpoints <= 0) //he dead
        {
            HandleDeath();
            return;
        }

        float damage = _maxHitPoints - hitpoints;
        if(damage > 0)
        {
            _renderer.material.color = Color.Lerp(colorStart, colorEnd, damage/_maxHitPoints);
        }
    }

    private void HandleDeath()
    {
        _collider.enabled = false;
        createGibPrefabs();

        speed = 0;
        var scale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
        scale.y /= 2;
        transform.localScale = scale;

        Invoke("HandleDestroy", 2.0f);
    }

    private void HandleDestroy ()
    {
        Destroy(this.gameObject);
    }
}
