using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target; // Referencia al transform del objeto a seguir.
    public float smoothSpeed = 0.125f; // Velocidad de seguimiento.
    public Vector3 offset; // Distancia entre la cámara y el objeto a seguir.

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
