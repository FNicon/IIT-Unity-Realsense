using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRealsenseClick : MonoBehaviour {
	public CursorControllerArkeolog cursorArkeolog;
	private void OnEnable() {
		CursorController.isHandClicked = true;
		if (cursorArkeolog != null) {
			cursorArkeolog.isHandClicked = true;
		}
	}
	private void OnDisable() {
		CursorController.isHandClicked = false;
		if (cursorArkeolog != null) {
			cursorArkeolog.isHandClicked = false;
		}
	}
}
