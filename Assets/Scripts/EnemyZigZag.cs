using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZag : EnemyBase
{
    public float frequency = 2f;
    public float amplitude = 1.5f;

    private float time;

    protected override void Move()
    {
        time += Time.deltaTime;

        float x = Mathf.Sin(time * frequency) * amplitude;
        Vector3 movement = new Vector3(x, -currentSpeed, 0);

        transform.Translate(movement * Time.deltaTime);
    }
}