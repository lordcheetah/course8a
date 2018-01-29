using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
	public GameObject[] stars;
	public int starsCollected = 0;
	public bool allStarsCollected = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Collect(Transform transform)
	{
		foreach (GameObject star in stars)
		{
			if (star.transform == transform)
			{
				star.SetActive (false);
				starsCollected++;
				if (starsCollected == stars.Length)
				{
					allStarsCollected = true;
					Debug.Log ("All Stars Collected");
				}
				break;
			}
		}
	}

	public void Reset()
	{
		foreach (GameObject star in stars)
		{
			star.SetActive (true);
			starsCollected = 0;
			allStarsCollected = false;
		}
	}
}
