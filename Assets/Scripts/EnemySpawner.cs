using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Asigna 3 tipos
    public float spawnRate = 2f;
    public float xRange = 8f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        float xPos = Random.Range(-xRange, xRange);
        Vector2 spawnPos = new Vector2(xPos, transform.position.y);
        Instantiate(enemyPrefabs[index], spawnPos, Quaternion.identity);
    }
}