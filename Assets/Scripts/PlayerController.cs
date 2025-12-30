using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    PlayerControls controls;

    void Awake()
    {

        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => Update();

          
    }


    public float speed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f; // cuanto dura el dash
    private bool isDashing = false;

    public Animator animator;
    public float MoveInput;
    void Update()
    {
        if (!isDashing) // solo se mueve normal si no está en dash
        {
            MoveInput = Input.GetAxis("Horizontal");

            animator.SetFloat("movement", Mathf.Abs(MoveInput));

            if (MoveInput > 0)
                transform.localScale = new Vector3(-1, 1, 1);

            if (MoveInput < 0)
                transform.localScale = new Vector3(1, 1, 1);

            transform.Translate(Vector2.right * MoveInput * speed * Time.deltaTime);

            // Dash con tecla E
            if (Input.GetKeyDown(KeyCode.E) && MoveInput != 0)
            {
                StartCoroutine(Dash(MoveInput));
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

    void OnEnable()
    {

        controls.Gameplay.Enable();
    }

    void OnDisable()
    {

        controls.Gameplay.Disable();
    }
}