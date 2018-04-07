using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorController : MonoBehaviour {
	public SpriteRenderer holdCotton;
	public SpriteRenderer holdBandage;
	private GameObject holdObject;
	private GameObject putObject;
	public CursorTransition transition;
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
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("wound")) {
			putObject = other.gameObject;
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("wound")) {
			putObject = null;
		}
	}
	void OnCursorDown() {
		transition.ChangeToClickSize();
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
		transition.ChangeToReleaseSize();
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
