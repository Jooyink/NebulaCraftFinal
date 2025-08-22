using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;

    void Update()
    {
        float move = Input.GetAxis("Horizontal"); // teclas A-D o flechas

        animator.SetFloat("movement", move);

        if (move > 0)
        {

            transform.localScale = new Vector3(-1, 1, 1);
         }
           if (move < 0)
        {

            transform.localScale = new Vector3(1, 1, 1);
         }

        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

        // Limitar movimiento (ejemplo, borde pantalla -8 a 8)
        float clampedX = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.position = new Vector2(clampedX, transform.position.y);
    }
}