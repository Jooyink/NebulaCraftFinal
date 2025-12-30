using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    PlayerControls controls;

    public float tiempoInicialDisparo = 0f;
    private float tiempoLimite;

    void Awake()
    {
        controls = new PlayerControls();

        // Callback del Input System
        controls.Gameplay.Disparo.performed += ctx => {
            if (tiempoLimite <= 0f)
            {
                Disparar();
                tiempoLimite = tiempoInicialDisparo;
            }
        };
    }

    void Start()
    {
        tiempoLimite = 0f;
    }

    void Update()
    {
        // Contador de cooldown
        tiempoLimite -= Time.deltaTime;
    }

    void Disparar()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
    }
    
    void OnEnable()      // <-- Nombre correcto
    {
        controls.Enable();
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
        controls.Disable();
    }
}