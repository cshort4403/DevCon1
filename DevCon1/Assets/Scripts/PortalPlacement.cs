using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PortalPlacement : MonoBehaviour
{
    public GameObject portalPrefab; // The portal prefab
    public Transform placementPoint; // The point from where the portal will be placed
    public float placementRate = 0.5f; // Time between placing portals 

    private float nextPlacementTime = 0f; // Variable for resetting placement time

    public bool canPlace; // Bool check for collisions

    void OnTriggerExit(Collider other) // When not colliding
    {
        Debug.Log("Able to place portal");
        canPlace = true; 
    }

    void OnTriggerEnter(Collider other) // When colliding
    {
        Debug.Log("Cannot place portal");
        canPlace = false;
    }

    void Update()
    {
        if (canPlace == true) // Collision check
        {
            // Checks if enough time has passed since the last placement
            if (Input.GetButton("Fire1") && Time.time >= nextPlacementTime)
            {
                nextPlacementTime = Time.time + placementRate; // Sets a cooldown period for how often the player can place 
                Place();
            }
        }
    }

    private void Place()
    {
        if (portalPrefab != null) // Exception Check
        {
            // Instantiate the portal
            GameObject portal = Instantiate(portalPrefab, placementPoint.position, placementPoint.rotation);
        }
    }
}
