using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float dashSpeed = 12f;
    public float dashDuration = 0.2f;

    [Header("Dash After Image")]
    public GameObject dashImagePrefab;
    public float afterImageDelay = 0.05f;

    private Rigidbody2D rb;
    private bool isDashing = false;
    private float moveInput;

    public Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing) return;

        moveInput = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("movement", Mathf.Abs(moveInput));

        if (moveInput > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(1, 1, 1);

        if (Input.GetKeyDown(KeyCode.E) && moveInput != 0)
        {
            StartCoroutine(Dash(moveInput));
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }

    IEnumerator Dash(float direction)
    {
        isDashing = true;

        float time = 0f;
        float afterImageTimer = 0f;

        rb.velocity = new Vector2(direction * dashSpeed, 0);

        while (time < dashDuration)
        {
            afterImageTimer += Time.deltaTime;
            if (afterImageTimer >= afterImageDelay)
            {
                SpawnAfterImage();
                afterImageTimer = 0;
            }

            time += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }

    void SpawnAfterImage()
    {
        GameObject img = Instantiate(
            dashImagePrefab,
            transform.position,
            transform.rotation
        );

        SpriteRenderer sr = img.GetComponent<SpriteRenderer>();
        sr.sprite = GetComponent<SpriteRenderer>().sprite;
        sr.flipX = GetComponent<SpriteRenderer>().flipX;
    }
}