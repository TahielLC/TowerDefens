using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    public float Mass = 15f;
    public float MaxVelocity = 3f;
    public float MaxForce = 15f;

    public float distanciaSeguridad = 5f;  // Distancia mínima a la que escapar
    private Vector3 velocity;
    public Transform target;

    private void Start()
    {
        velocity = Vector3.zero;
    }

    private void Update()
    {
        // Calcular la dirección inversa (de escape) desde el objetivo
        Vector3 desiredVelocity = transform.position - target.position;

        // Si estamos más lejos que la distancia de seguridad, no hacer nada
        if (desiredVelocity.magnitude > distanciaSeguridad)
        {
            velocity = Vector3.zero;  // Detener la velocidad si está fuera del rango de seguridad
            return;
        }

        // Normalizar la velocidad deseada y multiplicarla por la velocidad máxima
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        // Calcular la fuerza de steering
        Vector3 steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);  // Limitar la fuerza de dirección
        steering /= Mass;

        // Aplicar la velocidad resultante
        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;

        // Alinear la dirección del objeto con el movimiento
        if (velocity != Vector3.zero)
        {
            transform.forward = velocity.normalized;
        }
    }
}
