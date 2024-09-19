using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLogic : MonoBehaviour
{
    [SerializeField]
    public GameObject portalManager;

    [SerializeField]
    private GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        portal = this.gameObject;

        if(portalManager == null)
        {
            Console.Error.WriteLine("No portal manager attached to portal prefab");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        portalManager.GetComponent<PortalManager>().EnterPortal(portal, other.gameObject);
    }

}
