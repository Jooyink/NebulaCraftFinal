using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movimiento del enemigo")]
    public float speed = 2f; // Velocidad hacia abajo

    private void Update()
    {
        // Movimiento constante hacia abajo
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }


    }
}