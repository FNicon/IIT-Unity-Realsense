using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButtonManager : MonoBehaviour {
	public List<GameObject> buttonObjects;
	//public string[] sceneToLoad;
	private void Awake() {
		FindButtons();
		ChangeComponentButtons();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void FindButtons() {
		Button[] buttonArrays = FindObjectsOfType<Button>();
		for (int i=0; i<buttonArrays.Length; i++) {
			buttonObjects.Add(buttonArrays[i].gameObject);
		}
	}

	private void ChangeComponentButtons() {
		int i = 0;
		foreach (GameObject button in buttonObjects) {
			button.AddComponent<CustomButton>();
			button.AddComponent<BoxCollider2D>();
			button.GetComponent<BoxCollider2D>().isTrigger = true;
			//button.GetComponent<BoxCollider2D>().size *= 100;
			button.GetComponent<CustomButton>().mouseTag = FindObjectOfType<RealsenseClick>().tag;
			button.GetComponent<CustomButton>().sceneLoader = FindObjectOfType<SceneLoader>();
			//button.GetComponent<CustomButton>().sceneToLoad = sceneToLoad[i];
			i = i + 1;
		}
	}
}
