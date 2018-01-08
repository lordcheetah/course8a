using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePort : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Throwable")
		{
			transform.position = new Vector3 (transform.forward.x * 2 + transform.position.x, transform.forward.y * 2 + transform.position.y + 1f, transform.forward.z * 2 + transform.position.z);
		}
	}
}
