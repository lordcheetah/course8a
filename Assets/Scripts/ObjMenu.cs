using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMenu : MonoBehaviour
{
	public List<GameObject> objectList; //handled automatically at start
	public List<GameObject> objectPrefabList; //set manually in inspector and MUST match order of scene menu objects
	public int currentObject = 0;
	public bool isMenuShown = false;

	// Use this for initialization
	void Start ()
	{
		foreach (Transform child in transform)
		{
			objectList.Add (child.gameObject);
		}
	}

	public void MenuLeft()
	{
		isMenuShown = true;
		objectList [currentObject].SetActive (false);
		Debug.Log ("currentObject" + currentObject.ToString());
		currentObject--;
		if (currentObject < 0)
		{
			currentObject = objectList.Count - 1;
		}
		objectList [currentObject].SetActive (true);
		Debug.Log ("currentObject" + currentObject.ToString());
	}

	public void MenuRight()
	{
		isMenuShown = true;
		objectList [currentObject].SetActive (false);
		Debug.Log ("currentObject" + currentObject.ToString());
		currentObject++;
		if (currentObject > objectList.Count - 1)
		{
			currentObject = 0;
		}
		objectList [currentObject].SetActive (true);
		Debug.Log ("currentObject" + currentObject.ToString());
	}

	public void MenuShow()
	{
		isMenuShown = true;
		objectList [currentObject].SetActive (true);
		Debug.Log ("currentObject" + currentObject.ToString());
	}

	public void MenuHide()
	{
		isMenuShown = false;
		objectList [currentObject].SetActive (false);
		Debug.Log ("currentObject" + currentObject.ToString());
	}

	public void SpawnCurrentObject()
	{
		Instantiate (objectPrefabList [currentObject], objectList [currentObject].transform.position, objectList [currentObject].transform.rotation);
	}
}
