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

    public Animator animatorHit;


 private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Enemy") || other.CompareTag("EnemyProyectile"))
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.explosionSFX);

        Destroy(other.gameObject);
        Instantiate(explotionPrefab, transform.position, Quaternion.identity);

        GameManager.instance.vida -= 1;
        animatorHit.SetTrigger("Hit");

        Camera.main.GetComponent<CamaraShake>()
            .Shake(0.15f, 0.08f);

        UpdateLivesUI();

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
                    animatorHit.SetTrigger("Hit");
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