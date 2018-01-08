using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeUI : MonoBehaviour
{
	public Canvas canvas;
	public Text text;
	float count = 5f;
	bool firstscreen = true;
	bool secondscreen = false;
	bool thirdscreen = false;
	bool fourthscreen = false;
	bool hidescreen = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (firstscreen)
		{
			count -= Time.deltaTime;
			if (count <= 0)
			{
				text.text = "Use the right touchpad or thumbstick to select structures to get the ball from the platform to the white cube goal";
				count = 5f;
				firstscreen = false;
				secondscreen = true;
			}
		} else if (secondscreen)
		{
			count -= Time.deltaTime;
			if (count <= 0)
			{
				text.text = "Use the left trigger to teleport around the level";
				count = 5f;
				secondscreen = false;
				thirdscreen = true;
			}
		} else if (thirdscreen)
		{
			count -= Time.deltaTime;
			if (count <= 0)
			{
				text.text = "Use the right trigger to pick up structure or the ball";
				count = 5f;
				thirdscreen = false;
				hidescreen = true;
			}
		} else if (hidescreen)
		{
			count -= Time.deltaTime;
			if (count <= 0)
			{
				hidescreen = false;
				canvas.gameObject.SetActive (false);
			}
		}
	}
}
