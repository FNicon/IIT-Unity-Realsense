using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTransition : MonoBehaviour {
	private float transitionTime;
	public float clickTransitionTime;
	public float releaseTransitionTime;
	public Vector3 onClickedSize;
	public Vector3 onReleaseSize;
	private Vector3 newSize;
	// Use this for initialization
	void Start () {
		newSize = onReleaseSize;
		transitionTime = releaseTransitionTime;
	}
	// Update is called once per frame
	void Update () {
		ChangeSize();
	}
	public void ChangeSize() {
		transform.localScale = Vector3.MoveTowards(transform.localScale,newSize,Time.deltaTime * transitionTime);
	}
	public bool IsTransitionFinished() {
		return (transform.localScale.x == newSize.x);
	}
	public void ChangeToClickSize() {
		transitionTime = clickTransitionTime;
		newSize = onClickedSize;
	}
	public void ChangeToReleaseSize() {
		transitionTime = releaseTransitionTime;
		newSize = onReleaseSize;
	}
}
