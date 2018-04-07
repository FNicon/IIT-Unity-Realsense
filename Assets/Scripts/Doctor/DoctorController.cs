using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorController : MonoBehaviour {
	public Cotton holdCotton;
	public Bandage holdBandage;
	private GameObject holdObject;
	private GameObject putObject;
	public CursorTransition transition;
	private bool isHolding;
	// Use this for initialization
	void Start () {
		holdBandage.ViewBandage(false);
		holdCotton.ViewCotton(false);
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
	IEnumerator Transition() {
		yield return new WaitUntil(() => transition.IsTransitionFinished());
		if (holdObject!= null) {
			if (holdObject.CompareTag("cotton")) {
				holdCotton.ViewCotton(isHolding);
			} else if (holdObject.CompareTag("bandage")) {
				holdBandage.ViewBandage(isHolding);
			}
			if (!isHolding) {
				holdObject = null;
			}
		}
	}
	void OnCursorDown() {
		transition.ChangeToClickSize();
		holdObject = CursorController.instance.GetFirstClickedObj();
		if (holdObject!= null) {
			isHolding = true;
			StartCoroutine(Transition());
		}
	}
	void OnCursorUp() {
		transition.ChangeToReleaseSize();
		if (holdObject!= null) {
			isHolding = false;
			StartCoroutine(Transition());
		}
	}
}
