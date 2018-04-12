using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {
	public RectTransform selectedObject;
	public RectTransform[] childObjects;
	// Use this for initialization
	void Start () {
		UpdateChildObjects();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SwipeRight() {
		Transform tempObject;
		tempObject = childObjects[childObjects.Length - 1];
		for (int i = 0; i<childObjects.Length - 1;i++) {
			childObjects[i].SetSiblingIndex(i + 1);
		}
		childObjects[childObjects.Length - 1].SetSiblingIndex(0);
		UpdateChildObjects();
	}
	void UpdateChildObjects() {
		int childCount = transform.childCount;
		for (int i = 0; i < childCount; i++) {
			childObjects[i] = transform.GetChild(i).GetComponent<RectTransform>();
		}
		selectedObject = childObjects[2];
	}
	public void SwipeLeft() {
		Transform tempObject;
		tempObject = childObjects[0];
		for (int i = childObjects.Length - 1; i>0;i--) {
			childObjects[i].SetSiblingIndex(i - 1);
		}
		childObjects[0].SetSiblingIndex(childObjects.Length - 1);
		UpdateChildObjects();
	}
}
