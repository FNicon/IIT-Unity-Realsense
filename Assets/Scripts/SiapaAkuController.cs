using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SiapaAkuController : MonoBehaviour {

	public SceneLoader sceneLoader;
	public RectTransform selectedObject;
	public RectTransform[] childObjects;

	public Button leftButton;
	public Button rightButton;
	int counter = 0;
	public SFXManager sound;
	// Use this for initialization
	private void Awake() {
		GameObject temp = GameObject.Find("Scene Loader");
		if(temp != null)
			sceneLoader = temp.GetComponent<SceneLoader>();
		UpdateChildObjects();
		UpdateButton();
		PlaySound();
		//leftButton.gameObject.SetActive(false);
	} 
	// Update is called once per frame
	void Update () {
		
	}

	public void SwipeRight() {
		if(counter < childObjects.Length-1){
			//Transform tempObject;
			//tempObject = childObjects[childObjects.Length - 1];
			for (int i = 0; i<childObjects.Length - 1;i++) {
				childObjects[i].SetSiblingIndex(i + 1);
			}
			childObjects[childObjects.Length - 1].SetSiblingIndex(0);
			//ResetChildObject(3);
			UpdateChildObjects();
			counter++;
			PlaySound();
		} 
		UpdateButton();
		/*if(counter >= childObjects.Length-1) 
			rightButton.gameObject.SetActive(false);

		if(counter > 0)
			leftButton.gameObject.SetActive(true);*/
	}
	void ResetChildObject(int previouslyChoosenChild) {
		Vector3 currentChildScale = childObjects[previouslyChoosenChild].transform.localScale;
		childObjects[previouslyChoosenChild].transform.localScale = new Vector3(
			currentChildScale.x - 0.2f,currentChildScale.y - 0.2f,currentChildScale.z - 0.2f);
	}
	void PlaySound() {
		sound.PlayFromString((counter + 1).ToString());
	}
	void UpdateChildObjects() {
		int childCount = transform.childCount;
		for (int i = 0; i < childCount; i++) {
			childObjects[i] = transform.GetChild(i).GetComponent<RectTransform>();
		}
		selectedObject = childObjects[1];
	}
	void UpdateButton() {
		if (counter > 0) {
			leftButton.gameObject.SetActive(true);
		} else {
			leftButton.gameObject.SetActive(false);
		}
		if (counter < childObjects.Length-1) {
			rightButton.gameObject.SetActive(true);
		} else {
			rightButton.gameObject.SetActive(false);
		}
	}
	public void SwipeLeft() {
		if(counter > 0){
			//Transform tempObject;
			//tempObject = childObjects[0];
			for (int i = childObjects.Length - 1; i>0;i--) {
				childObjects[i].SetSiblingIndex(i - 1);
			}
			childObjects[0].SetSiblingIndex(childObjects.Length - 1);
			//ResetChildObject(1);
			UpdateChildObjects();
			counter--;
			PlaySound();
		}
		UpdateButton();
		/*
		if(counter <= 0)
			leftButton.gameObject.SetActive(false);

		if(counter < childObjects.Length-2)
			rightButton.gameObject.SetActive(true);*/
	}

}
