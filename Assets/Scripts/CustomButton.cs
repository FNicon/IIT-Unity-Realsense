using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour {
	public string mouseTag;
	public SceneLoader sceneLoader;
	public string sceneToLoad;
	public bool isHover;
	public Animator buttonAnimation;
	Button button;
	bool once;
	// Use this for initialization
	void Start () {
		once = false;
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag(mouseTag)) {
			isHover = true;
			button = GetComponent<Button>();
		}
	}
	public void OnCursorDown(){
		if (isHover) {
			if (button != null) {
				if (!once) {
					button.onClick.Invoke();
					once = true;
				}
				//sceneLoader.loadSpecificScene(sceneToLoad);
			}	
		}
	}

	public void OnCursorUp(){
		if (isHover) {
			//sceneLoader.loadSpecificScene(sceneToLoad);	
		}
	}
}
