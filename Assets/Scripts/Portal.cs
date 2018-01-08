using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	public GameObject destinationPortal;
	public GameObject PortalEndPrefab;
	private Transform destinationTransform;

	// Use this for initialization
	void Start ()
	{
		Transform portalendTransform;
		portalendTransform = transform;
		portalendTransform.position = new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z);
		SetDestination(Instantiate (PortalEndPrefab, transform.position, transform.rotation));
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SetDestination(GameObject portal)
	{
		destinationPortal = portal;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Throwable")
		{
			destinationTransform.position = new Vector3 (destinationPortal.transform.position.x, destinationPortal.transform.position.y + 1f, destinationPortal.transform.position.z);
			col.transform.position = destinationTransform.position;
		}
	}
}
