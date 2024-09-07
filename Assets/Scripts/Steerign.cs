using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steerign : MonoBehaviour
{

    public float followSeed = 15f;
    public float slowdownDistance = 1f;


    Vector2 velocity = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 playerDistance = (targetPosition - (Vector2)transform.position);
        Vector2 desiredVelocity = playerDistance.normalized * followSeed;
        Vector2 steerign = desiredVelocity - velocity;

        velocity += steerign * Time.deltaTime;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
