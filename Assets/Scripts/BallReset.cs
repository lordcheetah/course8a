using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
	Vector3 originalPosition;
	public StarManager sm;
	public string nextLevel;
	private Renderer rend;
	private Color tempColor;

	// Use this for initialization
	void Start ()
	{
		originalPosition = transform.position;
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Start")
		{
			gameObject.layer = 0;
			tempColor.r = 1f;
			tempColor.g = 1f;
			tempColor.b = 1f;
			rend.material.color = tempColor;
		}
		if (col.collider.tag == "Ground")
		{
			Reset ();
		} else if (col.collider.tag == "Collectable")
		{
			sm.Collect (col.transform);
		} else if (col.collider.tag == "Goal")
		{
			if (sm.allStarsCollected)
			{
				NextLevel ();
			} else
			{
				Reset ();
			}
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "Start")
		{
			gameObject.layer = 8;
			tempColor.r = 1f;
			tempColor.g = 0f;
			tempColor.b = 0f;
			rend.material.color = tempColor;
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
