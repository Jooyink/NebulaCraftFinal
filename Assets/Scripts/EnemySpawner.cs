using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración del spawn")]
    public GameObject enemyPrefab;     // Prefab del enemigo
    public Collider2D spawnArea;       // Área donde spawnearán los enemigos
    public float spawnIntervalMin = 1f; 
    public float spawnIntervalMax = 3f; 

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private System.Collections.IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);

            Vector2 randomPoint = GetRandomPointInCollider(spawnArea);
            Instantiate(enemyPrefab, randomPoint, Quaternion.identity);
        }
    }

    private Vector2 GetRandomPointInCollider(Collider2D col)
    {
        Bounds bounds = col.bounds;
        Vector2 point;
        do
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            point = new Vector2(randomX, randomY);
        }
        while (!col.OverlapPoint(point));

        return point;
    }
}