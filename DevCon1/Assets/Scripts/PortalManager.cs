using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Class to manage the lifetime of the portals
/// </summary>
public class PortalManager : MonoBehaviour
{
    //Properties with a private backend
    [SerializeField]
    private GameObject portalPrefab;
    public GameObject PortalObject
    { get { return portalPrefab; } set { portalPrefab = PortalObject; } }

    //Rigid body of the portal prefab
    private Rigidbody rb;

    //Queue of portals active in the game using a first in first out approach
    [SerializeField]
    public Queue<GameObject> portalQueue = new Queue<GameObject>();

   

    // Start is called before the first frame update
    void Start()
    {
        if (portalPrefab == null) 
        {
            Console.Error.WriteLine("You forgot to add a valid portal prefab to the portal manager class!");
        }
        //Portal must have a rigid body component!
        rb = portalPrefab.GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Make a portal appear at a specified location, position, and scale.
    /// </summary>
    /// <param name="transform"></param>
    public void SpawnPortal(Transform transform)
    {
        if(portalQueue.Count < 2)
        {
            Instantiate(portalPrefab, transform);
            portalQueue.Enqueue(portalPrefab);
        }
        else
        {
            DestroyPortal(portalQueue.Peek());
			Instantiate(portalPrefab, transform);
			portalQueue.Enqueue(portalPrefab);
		}
    }
    /// <summary>
    /// Attempt to call OnDestroy method of the given portal and remove it from the queue
    /// </summary>
    /// <param name="portal"></param>
    public void DestroyPortal(GameObject portal)
    {
        portal.SendMessage("OnDestroy");
        portalQueue.Dequeue();
    }
    
    /// <summary>
    /// Call this from the OnCollisionEnter method in the portal prefab. <paramref name="portal"/> 
    /// should be "this" and <paramref name="other"> should be the player or whatever collided with the portal.
    /// </summary>
    /// <param name="portal"></param>
    /// <param name="other"></param>
    public void EnterPortal(GameObject portal, GameObject other)
    {
        if (!portalQueue.Contains(portal))
        {
            Console.Error.WriteLine("The portal you entered is not managed properly or doesn't exist!");
        }

        if(portalQueue.First() == portal)
        {
            other.transform.position = portalQueue.Last().transform.position;
        }
        else if (portalQueue.Last() == portal)
        {
			other.transform.position = portalQueue.First().transform.position;
		}
        else
        {
			Console.Error.WriteLine("The portal you entered is not first or last in the queue! (It should be)");
		}

        //TODO: Add velocity leaving the portal so you do not immediatly go back through


    }
   
}
