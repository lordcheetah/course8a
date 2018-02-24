using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRight : MonoBehaviour
{
	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;
	public float throwForce = 1.5f;

	//Swipe
	public float swipeSum;
	public float touchLast;
	public float touchCurrent;
	public float distance;
	public bool hasSwipedLeft;
	public bool hasSwipedRight;
	public ObjMenu objectMenuManager;
	public BallReset br;
	public bool ballHeld = false;

	// Use this for initialization
	void Start ()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		swipeSum = 0f;
		ballHeld = false;
	}

	// Update is called once per frame
	void Update ()
	{
		device = SteamVR_Controller.Input ((int)trackedObj.index);
		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Touchpad))
		{
			touchLast = device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
		}
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Touchpad))
		{
			// This code does not play well with Oculus. User must release the stick, not return it to center. Ugh
			touchCurrent = device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
			distance = touchCurrent - touchLast;
			touchLast = touchCurrent;
			swipeSum += distance;

			if (!hasSwipedRight)
			{
				if (swipeSum > 0.49f)
				{
					swipeSum = 0f;
					SwipeRight ();
					hasSwipedRight = true;
					hasSwipedLeft = false;
				}
			}
			if (!hasSwipedLeft)
			{
				if (swipeSum < -0.49f)
				{
					swipeSum = 0f;
					SwipeLeft ();
					hasSwipedRight = false;
					hasSwipedLeft = true;
				}
			}
			if(!objectMenuManager.isMenuShown)
				ShowMenu ();
		}
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Touchpad))
		{
			if(objectMenuManager.isMenuShown)
				HideMenu ();
			swipeSum = 0f;
			touchCurrent = 0;
			touchLast = 0;
			hasSwipedLeft = false;
			hasSwipedRight = false;
			Debug.Log ("TouchUp");
		}
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad))
		{
			//Spawn object currently selected by menu
			SpawnObject();
		}
	}

	void SpawnObject()
	{
		objectMenuManager.SpawnCurrentObject ();
	}

	void SwipeLeft()
	{
		objectMenuManager.MenuLeft ();
		Debug.Log ("SwipeLeft");
	}

	void SwipeRight()
	{
		objectMenuManager.MenuRight ();
		Debug.Log ("SwipeRight");
	}

	void ShowMenu()
	{
		objectMenuManager.MenuShow ();
		Debug.Log("ShowMenu");
	}

	void HideMenu()
	{
		objectMenuManager.MenuHide ();
		Debug.Log("HideMenu");
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag ("Throwable"))
		{
			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger))
			{
				if (br.release)
				{
					ThrowObject (col);
				}
			}
			else if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger))
			{
				GrabObject (col);
			}
		}

		if (col.gameObject.CompareTag ("Structure") || col.gameObject.CompareTag ("Target"))
		{
			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger))
			{
				ThrowObject (col);
			}
			else if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger))
			{
				GrabObject (col);
			}
		}
	}

	void GrabObject(Collider coli)
	{
		ballHeld = true;
		coli.transform.SetParent (gameObject.transform);
		coli.GetComponent<Rigidbody> ().isKinematic = true;
		device.TriggerHapticPulse (2000);
		Debug.Log ("You are touching down the trigger on an object");
	}
	void ThrowObject(Collider coli)
	{
		ballHeld = false;
		coli.transform.SetParent (null);
		Rigidbody rigidBody = coli.GetComponent<Rigidbody> ();
		if (coli.gameObject.CompareTag ("Throwable"))
			rigidBody.isKinematic = false;
		rigidBody.velocity = device.velocity * throwForce;
		rigidBody.angularVelocity = device.angularVelocity;
	}
}
