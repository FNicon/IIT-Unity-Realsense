using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour {
	public GameObject water;
	public float transitionTime;
	public Vector3 onClickedSize;
	public Vector3 onReleaseSize;
	public Vector3 newSize;
	private bool waterActive;
	// Use this for initialization
	void Start () {
		water.SetActive(false);
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
		newSize = onReleaseSize;
	}
	// Update is called once per frame
	void Update () {
		ChangeSize();
	}
	public void ChangeSize() {
		transform.localScale = Vector3.MoveTowards(transform.localScale,newSize,Time.deltaTime * transitionTime);
	}
	bool IsTransitionFinished() {
		return (transform.localScale.x == newSize.x);
	}
	IEnumerator Transition() {
		yield return new WaitUntil(() => IsTransitionFinished());
		water.SetActive(waterActive);
	}
	public void OnCursorDown() {
		if (Time.timeScale != 0) {
			newSize = onClickedSize;
			waterActive = true;
			StartCoroutine(Transition());
		}
	}
	public void OnCursorUp() {
		if (Time.timeScale != 0) {
			newSize = onReleaseSize;
			waterActive = false;
			water.SetActive(waterActive);
		}
	}
}
