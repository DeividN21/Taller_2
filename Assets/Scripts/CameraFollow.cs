using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al transform del objeto a seguir
    public float smoothSpeed = 5f; // Velocidad de suavizado

    void LateUpdate()
    {
        // Calcula la posición deseada de la cámara manteniendo la misma altura (eje Y)
        Vector3 desiredPosition = target.position;
        desiredPosition.y = transform.position.y;

        // Ajusta la posición de la cámara hacia la posición deseada
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}


