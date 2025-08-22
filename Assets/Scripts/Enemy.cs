using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreValue = 10;
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager.instance.AddScore(scoreValue);
        }
        else if (other.CompareTag("Player"))
        {
            GameManager.instance.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
