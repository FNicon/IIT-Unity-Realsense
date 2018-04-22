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
			childObjects[i].gameObject.SetActive(true);
			childObjects[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
		}
		childObjects[0].gameObject.SetActive(false);
		childObjects[4].gameObject.SetActive(false);
		if(selectedObject != null){
			selectedObject.GetChild(0).gameObject.SetActive(false);
			selectedObject.transform.localScale = Vector3.one;
		}
		selectedObject = childObjects[2];
		selectedObject.GetChild(0).gameObject.SetActive(true);
		selectedObject.GetChild(0).transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
		selectedObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
		selectedObject.GetComponent<Image>().color = Color.white;
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
