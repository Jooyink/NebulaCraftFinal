using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLives : MonoBehaviour
{
    public Image[] livesUI;          // Imágenes de los corazones
    public Animator[] livesAnimators; // Animators correspondientes a cada corazón
    public GameObject explotionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el jugador choca con un enemigo o proyectil
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("EnemyProyectile"))
        {
            Destroy(collision.collider.gameObject); // destruye el objeto que golpeó
            Instantiate(explotionPrefab, transform.position, Quaternion.identity); // efecto
            GameManager.instance.vida -= 1; // resta vida

            // Actualiza la UI de corazones
            UpdateLivesUI();

            // Si ya no hay vidas → destruye al jugador
            if (GameManager.instance.vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < livesUI.Length; i++)
        {
            if (i < GameManager.instance.vida)
            {
                // Corazones activos
                livesUI[i].enabled = true;
            }
            else
            {
                if (livesUI[i].enabled) // si estaba activo y ahora debe morir
                {
                    livesAnimators[i].SetTrigger("Muerte"); // dispara la animación
                }
                // OJO: no desactivamos el corazón aquí, eso lo hace la animación al final
            }
        }
    }

    // Este método lo llamas con un Animation Event al final de la animación "Muerte"
    public void DisableHeart(int index)
    {
        livesUI[index].enabled = false;
    }
}