using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<TargetMovement> _targets;
    [SerializeField] private EnemyMover _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] private float _spawnInterval = 2f;

    private float _nextSpawnTime;

    private void Awake()
    {
        _nextSpawnTime = Time.time + _spawnInterval;
    }

    private void Update()
    {
        if (Time.time - _nextSpawnTime >= _spawnInterval )
        {
            Spawn();
            _nextSpawnTime += _spawnInterval;
        }
    }

    private void Spawn()
    {
        int randomSpawnIndex = Random.Range(0, _spawnPoint.Count);
        Transform spawnPoint = _spawnPoint[randomSpawnIndex];

        var enemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
       
        enemy.SetMovementTarget(_targets[randomSpawnIndex]);       
    }
}
