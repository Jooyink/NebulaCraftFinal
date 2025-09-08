using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f; // cuanto dura el dash
    private bool isDashing = false;

    public Animator animator;

    void Update()
    {
        if (!isDashing) // solo se mueve normal si no está en dash
        {
            float move = Input.GetAxis("Horizontal");

            animator.SetFloat("movement", Mathf.Abs(move));

            if (move > 0)
                transform.localScale = new Vector3(-1, 1, 1);

            if (move < 0)
                transform.localScale = new Vector3(1, 1, 1);

            transform.Translate(Vector2.right * move * speed * Time.deltaTime);

            // Dash con tecla E
            if (Input.GetKeyDown(KeyCode.E) && move != 0)
            {
                StartCoroutine(Dash(move));
            }
        }
    }

    IEnumerator Dash(float direction)
    {
        isDashing = true;

        float time = 0;
        while (time < dashDuration)
        {
            transform.Translate(Vector2.right * direction * dashSpeed * Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }
}