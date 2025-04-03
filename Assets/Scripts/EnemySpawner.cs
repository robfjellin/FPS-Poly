using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;

    private float _timeTillNextSpawn = 2f;

    private void Update()
    {
        if (_timeTillNextSpawn >= 0f)
        {
            _timeTillNextSpawn -= Time.deltaTime;
        }
        else
        {
            _timeTillNextSpawn = 2f;
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
    
    
}
