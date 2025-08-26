using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [Header("Enemigos disponibles")]
    public GameObject[] enemigosPrefab; // prefabs diferentes de enemigos

    [Header("Configuración")]
    public float minTiempoSpawn = 1f;   // tiempo mínimo entre spawns
    public float maxTiempoSpawn = 3f;   // tiempo máximo entre spawns
    public int minCantidad = 1;         // cantidad mínima de enemigos por spawn
    public int maxCantidad = 3;         // cantidad máxima de enemigos por spawn

    private Collider2D zona; // collider que define el área de spawn
    private float tiempoProximoSpawn;

    void Start()
    {
        zona = GetComponent<Collider2D>();

        // Primer spawn aleatorio
        tiempoProximoSpawn = Random.Range(minTiempoSpawn, maxTiempoSpawn);
    }

    void Update()
    {
        tiempoProximoSpawn -= Time.deltaTime;

        if (tiempoProximoSpawn <= 0)
        {
            SpawnEnemies();

            // Reiniciar tiempo aleatorio
            tiempoProximoSpawn = Random.Range(minTiempoSpawn, maxTiempoSpawn);
        }
    }

    void SpawnEnemies()
    {
        // Elegir cantidad de enemigos aleatoria
        int cantidad = Random.Range(minCantidad, maxCantidad + 1);

        for (int i = 0; i < cantidad; i++)
        {
            // Elegir enemigo aleatorio del arreglo
            int randomIndex = Random.Range(0, enemigosPrefab.Length);
            GameObject enemigoElegido = enemigosPrefab[randomIndex];

            // Posición aleatoria dentro del collider
            Vector2 spawnPos = GetRandomPositionInCollider(zona);

            // Instanciar enemigo
            Instantiate(enemigoElegido, spawnPos, Quaternion.identity);
        }
    }

    Vector2 GetRandomPositionInCollider(Collider2D col)
    {
        Bounds bounds = col.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(x, y);
    }
}