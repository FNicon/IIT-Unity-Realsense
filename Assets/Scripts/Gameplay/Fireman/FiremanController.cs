using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour {
	public CursorTransition transition;
	public GameObject water;
	private bool waterActive;
	public SFXManager soundEffects;
	// Use this for initialization
	void Start () {
		water.SetActive(false);
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
	}
	IEnumerator Transition() {
		yield return new WaitUntil(() => transition.IsTransitionFinished());
		water.SetActive(waterActive);
		if (waterActive) {
			soundEffects.PlayFromString("air");
		}
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
			soundEffects.Stop();
			transition.ChangeToReleaseSize();
			waterActive = false;
			water.SetActive(waterActive);
		}
	}
}
