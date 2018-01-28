using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject target;

	private void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Throwable"))
		{
			Debug.Log ("Teleport");
			col.transform.position = target.transform.position + new Vector3 (0, 1, 0);
		}
	}
}
