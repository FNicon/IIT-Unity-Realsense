﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour {
	public string mouseTag;
	public bool isHover;
	public SFXManager soundEffects;
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
			soundEffects.PlayFromString("click");
		}
	}

	public void OnCursorUp(){
		if (isHover) {
			//sceneLoader.loadSpecificScene(sceneToLoad);	
		}
	}
	private void OnDisable() {
		isHover = false;
	}
}