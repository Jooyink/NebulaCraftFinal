using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Base Stats")]
    public float baseSpeed = 2f;
    protected float currentSpeed;

    protected virtual void Start()
    {
        currentSpeed = baseSpeed;
    }

    protected virtual void Update()
    {
        Move();
    }

    // Cada enemigo DEBE implementar su movimiento
    protected abstract void Move();

    public virtual void ApplyDifficulty(float speedMultiplier, float fireRateMultiplier)
    {
        currentSpeed = baseSpeed * speedMultiplier;
    }

    protected virtual void Shoot() { }
}