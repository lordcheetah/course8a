using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject target;
	public float offsetForwardTeleportation;

	private void Update()
	{
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("Target");
			Debug.Log ("Target Set");
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Throwable"))
		{
			//col.transform.position = target.transform.position + new Vector3 (0, 1, 0);
			Rigidbody body = col.gameObject.GetComponent<Rigidbody>();
			if (!body.isKinematic)
			{
				Vector3 targetForward = target.transform.forward;
				body.velocity = GetVelocityRotation(body.velocity.normalized, targetForward) * body.velocity;
				col.gameObject.transform.rotation = Quaternion.LookRotation(col.gameObject.transform.position - target.transform.position);
				col.gameObject.transform.position = target.transform.position + (targetForward * offsetForwardTeleportation);
				Debug.Log ("Teleport");
			}
		}
	}

	private Quaternion GetVelocityRotation(Vector3 velocityNormal, Vector3 targetForward)
	{
		return Quaternion.FromToRotation(velocityNormal, targetForward);
	}
}
