using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public float _generationSpeed= 5.0f;
    public Enemy[] _enemies;

    private float _generationCooldown;

    // Use this for initialization
    void Start () {
        _generationCooldown = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        _generationCooldown -= Time.deltaTime;
        if(_generationCooldown < 0)
        {
            _generationCooldown = _generationSpeed;
            foreach (Enemy enemy in _enemies)
            {
                SpawnEnemy(enemy);
            }
        }
	}

    private void SpawnEnemy(Enemy enemy)
    {
        var casing = Instantiate(enemy, transform.position, transform.rotation, null);
    }
}
