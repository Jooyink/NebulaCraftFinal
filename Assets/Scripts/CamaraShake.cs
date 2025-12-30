using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraShake : MonoBehaviour
{
    Vector3 originalPos;      // Guarda la posición original de la cámara
    float shakeDuration = 0f; // Cuánto tiempo debe durar el shake
    float shakeMagnitude = 0f;// Qué tan fuerte se mueve

    void Start()
    {
        // Se guarda la posición inicial UNA SOLA VEZ
        originalPos = transform.localPosition;
    }

    void Update()
    {
        // Si el shake está activo
        if (shakeDuration > 0)
        {
            // Movimiento aleatorio dentro de un círculo
            Vector2 randomOffset = Random.insideUnitCircle * shakeMagnitude;

            // Se suma a la posición original
            transform.localPosition = originalPos + new Vector3(
                randomOffset.x,
                randomOffset.y,
                0
            );

            // Reducimos el tiempo restante
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            // Cuando termina, volvemos EXACTAMENTE al lugar original
            shakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }

    // Función pública para ACTIVAR el shake
    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }
}