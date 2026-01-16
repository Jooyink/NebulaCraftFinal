using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DifficultLevel 
{
    public string levelName;
    public GameObject[] enemies;

    [Header("Spawn")]
    public float spawnMin;
    public float spawnMax;

    [Header("Modifiers")]
    public float speedMultiplier = 1f;
    public float fireRateMultiplier = 1f;
}