using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomButton : MonoBehaviour {
	public string mouseTag;
	public SceneLoader sceneLoader;
	public string sceneToLoad;
	public bool isHover;
	public Animator buttonAnimation;
	// Use this for initialization
	void Start () {
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag(mouseTag)) {
			isHover = true;
			//Debug.Log("Hover");
		}
	}
	public void OnCursorDown(){
		
	}

	public void OnCursorUp(){
		if (isHover) {
			sceneLoader.loadSpecificScene(sceneToLoad);	
		}
	}
}
