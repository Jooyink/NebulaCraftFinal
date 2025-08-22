using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CinematicController : MonoBehaviour
{
    [Header("Todas las imágenes de la cinemática")]
    public Image[] imagenes; // arrastra tus imágenes aquí

    [Header("Escena a cargar al finalizar (opcional)")]
    public string nextScene;

    [Header("Duración del fade en segundos")]
    public float fadeDuration = 1f;

    [Header("Tiempo que se muestra cada imagen antes de pasar a la siguiente")]
    public float tiempoPorImagen = 2f;

    private int indiceActual = 0;

    void Start()
    {
        // Hacer todas las imágenes transparentes menos la primera
        for (int i = 0; i < imagenes.Length; i++)
        {
            Color c = imagenes[i].color;
            imagenes[i].color = new Color(c.r, c.g, c.b, i == 0 ? 1f : 0f);
        }

        // Iniciar la cinemática automática
        StartCoroutine(AvanzarCinematica());
    }

    IEnumerator AvanzarCinematica()
    {
        while (indiceActual < imagenes.Length)
        {
            // Esperar el tiempo que dura la imagen
            yield return new WaitForSeconds(tiempoPorImagen);

            // Fade out de la imagen actual
            yield return StartCoroutine(FadeImagen(imagenes[indiceActual], 0f));

            indiceActual++;

            if (indiceActual < imagenes.Length)
            {
                // Fade in de la siguiente imagen
                yield return StartCoroutine(FadeImagen(imagenes[indiceActual], 1f));
            }
            else
            {
                // Si no hay más imágenes, carga la escena final
                if (!string.IsNullOrEmpty(nextScene))
                    SceneManager.LoadScene(nextScene);
                else
                    Debug.Log("Cinemática terminada.");
            }
        }
    }

    IEnumerator FadeImagen(Image img, float targetAlpha)
    {
        float startAlpha = img.color.a;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, t / fadeDuration);
            Color c = img.color;
            img.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }

        // Asegurarnos que llegue al alpha final
        Color final = img.color;
        img.color = new Color(final.r, final.g, final.b, targetAlpha);
    }

    
      public void Skip()
    {

        SceneManager.LoadScene("Game01");
    }
}