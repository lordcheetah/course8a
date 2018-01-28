using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
	public float air = 25;
	private Vector3 direction;
	private Rigidbody rb;

	/*private void OnTriggerEnter(Collider col)
	{
		Debug.Log ("Fan1");
		if (col.gameObject.CompareTag ("Throwable"))
		{
			Debug.Log ("Fan2");
			rb = col.gameObject.GetComponent<Rigidbody> ();
			direction = rb.transform.position - transform.position;
			rb.AddForceAtPosition (direction.normalized, transform.position);
		}
	}*/

	private void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag ("Throwable"))
		{
			Debug.Log ("Fan4");
			rb = col.gameObject.GetComponent<Rigidbody> ();
			direction = rb.transform.position - transform.position;
			rb.AddForce (direction.normalized * air);
		}
	}
}
