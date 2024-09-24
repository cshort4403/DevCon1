using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLogic : MonoBehaviour
{
	[SerializeField]
	private PortalManager pManager;
	public PortalManager portalManager
	{ get { return pManager; } set { pManager = portalManager; } }

	// Start is called before the first frame update
	void Start()
    {
        pManager = GameObject.FindGameObjectWithTag("PortalManager").GetComponent<PortalManager>();

        if(pManager == null)
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
		if (other.gameObject.CompareTag("Player"))
        {
            pManager.EnterPortal(gameObject, other.gameObject);
        }
    }

	private void OnDestroy()
	{
        Destroy(gameObject);
	}
}
