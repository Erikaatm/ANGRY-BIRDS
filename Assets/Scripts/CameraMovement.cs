using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform birdTransform;
    [SerializeField] private float xStopPosition;

    // Posicion inicial camara
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void LateUpdate()
    {
        // Seguimos al pajaro si
        if(birdTransform.position.x > transform.position.x)
        {
            transform.position = new Vector3(birdTransform.position.x, transform.position.y, transform.position.z);
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}
