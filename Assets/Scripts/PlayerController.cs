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

  
    }
}