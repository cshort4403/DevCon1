using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        // Check for correct GameObject
        if (other.gameObject.CompareTag("Destroyer"))
        {
            // Destroy this GameObject upon entering the trigger
            Destroy(gameObject);
        }
    }
}
