using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyBase
{
    public GameObject projectilePrefab;
    public float shootInterval = 2f;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(Shoot), 1f, shootInterval);
    }

    protected override void Move()
    {
        transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
    }

    protected override void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}