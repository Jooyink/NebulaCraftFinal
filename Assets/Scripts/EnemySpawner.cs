using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public DifficultLevel[] difficultyLevels;
    public Collider2D spawnArea;

    public float timePerLevel = 30f;
    private int currentLevel = 0;

    private void Start()
    {
        StartCoroutine(DifficultyProgression());
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator DifficultyProgression()
    {
        while (currentLevel < difficultyLevels.Length - 1)
        {
            yield return new WaitForSeconds(timePerLevel);
            currentLevel++;
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            DifficultLevel level = difficultyLevels[currentLevel];

            float waitTime = Random.Range(level.spawnMin, level.spawnMax);
            yield return new WaitForSeconds(waitTime);

            Vector2 spawnPoint = GetRandomPointInCollider(spawnArea);

            int enemyIndex = Random.Range(0, level.enemies.Length);
            GameObject enemyGO = Instantiate(
                level.enemies[enemyIndex],
                spawnPoint,
                Quaternion.identity
            );

            EnemyBase enemy = enemyGO.GetComponent<EnemyBase>();
            enemy.ApplyDifficulty(level.speedMultiplier, level.fireRateMultiplier);
        }
    }

    private Vector2 GetRandomPointInCollider(Collider2D col)
    {
        Bounds bounds = col.bounds;
        Vector2 point;

        do
        {
            point = new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y)
            );
        }
        while (!col.OverlapPoint(point));

        return point;
    }
}