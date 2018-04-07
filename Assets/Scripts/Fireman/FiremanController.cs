using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour {
	public GameObject water;
	public Vector3 OnClickedSize;
	public Vector3 OnReleaseSize;
	// Use this for initialization
	void Start () {
		water.SetActive(false);
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCursorDown() {
		water.SetActive(true);
	}
	public void OnCursorUp() {
		water.SetActive(false);
	}
}
