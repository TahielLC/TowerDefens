using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering3d : MonoBehaviour
{


    public float Mass = 15;
    public float MaxVelocity = 3;
    public float MaxForce = 15;

    public float mantenerDist = 1f;

    private Vector3 velocity;
    private Enemy enemy;
    public Transform target;
    private Rigidbody rb;

    private void Awake()
    {

    }
    private void Start()
    {
        velocity = Vector3.zero;

        enemy = this.GetComponent<Enemy>();


    }

    private void DisableSelf()
    {
        Debug.Log("Script desactivado");
        enabled = false;  // Desactivar este script
    }

    private void Update()
    {
        //target = enemy.torreActual.transform.Find("Origen");
        //        target = enemy.torreActual.transform;
        // solucionar cuando me salgo del rango de los objetos y no le las paso coordenadas a quien seguir
//        Debug.Log(enemy.torreActual);
        var desiredVelocity = target.transform.position - transform.position;
        // Si estamos dentro de la distancia mínima, detener el movimiento
        if (desiredVelocity.magnitude < mantenerDist)
        {
            velocity = Vector3.zero;

            return; // Salir de la función de Update para no actualizar la posición
        }

        desiredVelocity = desiredVelocity.normalized * MaxVelocity;



        var steering = desiredVelocity + velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;

        //Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
        //Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.magenta);

    }
}
