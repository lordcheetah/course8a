using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

	public int air = 25;
	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Ball"))
		{
			Debug.Log ("Fan");
			col.gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * air);
		}
	}
}
