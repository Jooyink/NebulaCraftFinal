using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject enemyProjectile;
    public float spawTimer;
    public float spawnMax = 10;
     public float spawMin = 5;

    // Start is called before the first frame update
    void Start()
    {
        spawTimer = Random.Range(spawMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        spawTimer -= Time.deltaTime;
        if (spawTimer <= 0)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            spawTimer=Random.Range(spawMin, spawnMax);
        }
    }
}