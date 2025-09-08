using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

      public float tiempoInicialDisparo = 0f; // cada 30 segundos
    private float tiempoLimite;

    void Start()
    {
        tiempoLimite = tiempoInicialDisparo; //Al inicio puedes disparar de inmediato
    }

    void Update()
    {
        tiempoLimite -= Time.deltaTime; // bajar -1 el tiempo inicial del disparo

        
            if (Input.GetKeyDown(KeyCode.Space) && tiempoLimite <= 0f) // Si Disparas Y también el tiempo esta en 0 se activa el disparo.
            {
                Disparar(); // dispara automáticamente
                tiempoLimite = tiempoInicialDisparo; // reinicia el contador
            }
        
    }

    void Disparar()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
    }
}