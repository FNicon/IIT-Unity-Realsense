using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour {
	public CursorTransition transition;
	public GameObject water;
	private bool waterActive;
	// Use this for initialization
	void Start () {
		water.SetActive(false);
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
	}
	IEnumerator Transition() {
		yield return new WaitUntil(() => transition.IsTransitionFinished());
		water.SetActive(waterActive);
	}
	public void OnCursorDown() {
		if (Time.timeScale != 0) {
			transition.ChangeToClickSize();
			waterActive = true;
			StartCoroutine(Transition());
		}
	}
	public void OnCursorUp() {
		if (Time.timeScale != 0) {
			transition.ChangeToReleaseSize();
			waterActive = false;
			water.SetActive(waterActive);
		}
	}
}
