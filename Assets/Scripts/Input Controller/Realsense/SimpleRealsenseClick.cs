using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRealsenseClick : MonoBehaviour {
	private void OnEnable() {
		CursorController.isHandClicked = true;
		if (CursorControllerArkeolog.instance != null) {
			CursorControllerArkeolog.instance.isHandClicked = true;
		}
	}
	private void OnDisable() {
		CursorController.isHandClicked = false;
		if (CursorControllerArkeolog.instance != null) {
			CursorControllerArkeolog.instance.isHandClicked = false;
		}
	}
}
