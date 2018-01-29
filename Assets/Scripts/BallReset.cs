using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
	Vector3 originalPosition;
	public StarManager sm;
	public GameObject start;
	public string nextLevel;
	private Renderer rend;
	private Color tempColor;
	public bool release;
	public ControllerRight cr;

	// Use this for initialization
	void Start ()
	{
		originalPosition = transform.position;
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (cr.ballHeld)
		{
			float distance = Vector3.Distance (start.transform.position, transform.position);
			if (distance > 2.0f)
			{
				gameObject.layer = 8;
				tempColor.r = 1f;
				tempColor.g = 0f;
				tempColor.b = 0f;
				rend.material.color = tempColor;
				release = false;
			} else
			{
				gameObject.layer = 0;
				tempColor.r = 1f;
				tempColor.g = 1f;
				tempColor.b = 1f;
				rend.material.color = tempColor;
				release = true;
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			Reset ();
		}
		else if (col.collider.tag == "Collectable")
		{
			sm.Collect (col.transform);
		}
		else if (col.collider.tag == "Goal")
		{
			Debug.Log (sm.allStarsCollected.ToString ());
			if (sm.allStarsCollected)
			{
				NextLevel ();
			} 
			else
			{
				Reset ();
			}
		}
	}

	void Reset()
	{
		transform.position = originalPosition;
		sm.Reset ();
	}

	void NextLevel()
	{
		SteamVR_LoadLevel.Begin (nextLevel);
	}
}
