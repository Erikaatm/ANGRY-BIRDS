using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float maxDistance;

    private Camera mainCamera;
    private Rigidbody2D rb;
    private Vector2 startPosition, clampedPosition; 

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Se queda en el aire ignorando el rigidbody
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        Vector2 dragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        clampedPosition = dragPosition;

        float dragDistance = Vector2.Distance(startPosition, dragPosition);

        // Comprobamos que la distancia que cogemos el pajaro sea mayor a la distancia maxima
        if (dragDistance > maxDistance)
        {
            clampedPosition = startPosition + (dragPosition - startPosition).normalized * maxDistance;
        }

        if (dragPosition.x > startPosition.x)
        {
            clampedPosition.x = startPosition.x;
        }


        transform.position = clampedPosition;
    }

    private void OnMouseUp()
    {
        Throw();
    }

    private void Throw()
    {
        rb.isKinematic = false;
        // Calculamos la distancia
        Vector2 throwVector = startPosition - clampedPosition;
        // Añadimos una fuerza
        rb.AddForce(throwVector * force);

        float resetTime = 5f;
        Invoke("Reset", resetTime);
    }

    private void Reset()
    {
        transform.position = startPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        mainCamera.GetComponent<CameraMovement>().ResetPosition();
    }
}
