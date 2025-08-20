using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UiButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    void Awake()
    {
        // Obtiene el Animator del mismo botón
        animator = GetComponent<Animator>();
    }

    // Cuando el mouse entra
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.Play("ButtonHover"); // tu animación de hover
    }

    // Cuando el mouse sale
    public void OnPointerExit(PointerEventData eventData)
    {
        animator.Play("ButtonNormal"); // vuelve al estado normal
    }
}