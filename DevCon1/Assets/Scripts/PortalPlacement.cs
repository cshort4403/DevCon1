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

    void Update()
    {
        // Check for player input and placement time
        if (Input.GetButton("Fire1") && Time.time >= nextPlacementTime) 
        {
            nextPlacementTime = Time.time + placementRate; // Prevents player from placing until next placement time
            Place();
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
