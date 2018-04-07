using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorController : MonoBehaviour {
	public SpriteRenderer holdCotton;
	public SpriteRenderer holdBandage;
	private GameObject holdObject;
	// Use this for initialization
	void Start () {
		holdBandage.enabled = false;
		holdCotton.enabled = false;
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCursorDown() {
		holdObject = CursorController.instance.GetFirstClickedObj();
		if (holdObject!= null) {
			if (holdObject.CompareTag("cotton")) {
				holdCotton.enabled = true;
			} else if (holdObject.CompareTag("bandage")) {
				holdBandage.enabled = true;
			}
		}
	}
	void OnCursorUp() {
		if (holdObject!= null) {
			if (holdObject.CompareTag("cotton")) {
				holdCotton.enabled = false;
			} else if (holdObject.CompareTag("bandage")) {
				holdBandage.enabled = false;
			}
			holdObject = null;
		}
	}
}
