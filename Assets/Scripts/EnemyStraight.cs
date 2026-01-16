using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraight : EnemyBase
{
    protected override void Move()
    {
        transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}