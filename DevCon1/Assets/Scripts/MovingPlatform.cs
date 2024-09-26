using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Starting point
    public Transform pointB; // Ending point
    public float speed = 2f; // Speed of movement
    private Vector3 targetPosition;

    public Color gizmoColor = Color.red; // Color of the Gizmo
    public float sphereRadius = 0.5f; // Radius of the Gizmo sphere

    void Start()
    {
        targetPosition = pointB.position; // Start by moving towards pointB
    }

    void Update()
    {
        // Move the platform
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Checks if platform position is equal to pointA, if true set target position to pointB 
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor; // Set the Gizmo color

        // Draw a sphere in unity editor at each point's position
        Gizmos.DrawSphere(pointA.position, sphereRadius); 
        Gizmos.DrawSphere(pointB.position, sphereRadius);

        // Draw a line in unity editor between both points
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}
