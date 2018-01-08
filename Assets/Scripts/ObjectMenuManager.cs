using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour
{
	public List<GameObject> objectList; //handled automatically at start
	public List<ObjectPrefab> objectPrefabList; //set manually in inspector and MUST match order of scene menu objects
	public int currentObject = 0;

	private Renderer rend;
	private Color tempColor;

	[Serializable]
	public class ObjectPrefab
	{
		public GameObject item;
		public int itemLimit;
		public int itemRemain;
	}

	// Use this for initialization
	void Start ()
	{
		tempColor.r = 0.6f;
		tempColor.g = 0.6f;
		tempColor.b = 0.6f;

		foreach (Transform child in transform)
		{
			objectList.Add (child.gameObject);
		}

		foreach (ObjectPrefab op in objectPrefabList)
		{
			op.itemRemain = op.itemLimit;
		}
	}

	public void MenuLeft()
	{
		objectList [currentObject].SetActive (false);
		currentObject--;
		if (currentObject < 0)
		{
			currentObject = objectList.Count - 1;
		}
		objectList [currentObject].SetActive (true);
		if (objectPrefabList [currentObject].itemRemain == 0)
		{
			rend = objectList [currentObject].GetComponent<Renderer>();
			rend.material.color = tempColor;
		}
	}

	public void MenuRight()
	{
		objectList [currentObject].SetActive (false);
		currentObject++;
		if (currentObject > objectList.Count - 1)
		{
			currentObject = 0;
		}
		objectList [currentObject].SetActive (true);
	}

	public void SpawnCurrentObject()
	{
		if (objectPrefabList [currentObject].itemRemain > 0)
		{
			Instantiate (objectPrefabList [currentObject].item, objectList [currentObject].transform.position, objectList [currentObject].transform.rotation);
			--objectPrefabList [currentObject].itemRemain;
		}
	}
}
