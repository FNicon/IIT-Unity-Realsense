using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButtonManager : MonoBehaviour {
	public List<GameObject> buttonObjects;
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
			CustomButton buttonCustom = button.GetComponent<CustomButton>();
			BoxCollider2D buttonCollider = button.GetComponent<BoxCollider2D>();
			if (buttonCustom == null) {
				button.AddComponent<CustomButton>();
				buttonCustom = button.GetComponent<CustomButton>();
			}
			if (buttonCollider == null) {
				button.AddComponent<BoxCollider2D>();
				buttonCollider = button.GetComponent<BoxCollider2D>();
			}
			buttonCollider.isTrigger = true;
			buttonCollider.size *= 100;
			buttonCustom.mouseTag = FindObjectOfType<RealsenseClick>().tag;
			//buttonCustom.sceneLoader = FindObjectOfType<SceneLoader>();
			//buttonCustom.soundEffects = FindObjectOfType<SFXManager>();
			//button.GetComponent<CustomButton>().sceneToLoad = sceneToLoad[i];
			i = i + 1;
		}
	}
}
