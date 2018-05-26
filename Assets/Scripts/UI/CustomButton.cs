using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour {
	public string mouseTag;
	public bool isHover;
	public SFXManager soundEffects;
	private Sprite normalSprite;
	// Use this for initialization
	void Start () {
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
		normalSprite = GetComponent<Button>().image.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag(mouseTag)) {
			isHover = true;
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(mouseTag)) {
			soundEffects.PlayFromString("hover");
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag(mouseTag)) {
			isHover = false;
		}
	}
	public void OnCursorDown(){
		if (isHover) {
			GetComponent<Button>().onClick.Invoke();
			GetComponent<Button>().image.sprite = GetComponent<Button>().spriteState.pressedSprite;
			soundEffects.PlayFromString("click");
		}
	}

	public void OnCursorUp(){
		if (isHover) {
			//sceneLoader.loadSpecificScene(sceneToLoad);	
		}
		GetComponent<Button>().image.sprite = normalSprite;
	}
	private void OnDisable() {
		isHover = false;
	}
	private void OnDestroy() {
		CursorController.OnMouseDown -= OnCursorDown;
		CursorController.OnMouseUp -= OnCursorUp;
	}
}
