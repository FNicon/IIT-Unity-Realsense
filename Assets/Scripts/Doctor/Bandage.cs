using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandage : MonoBehaviour {
	private SpriteRenderer bandageImage;
	public bool isOnTrigger;
	public Vector2 offsetMousePosition;
	private bool onHold;
	private void Awake() {
		bandageImage = GetComponent<SpriteRenderer>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (IsOnHold()) {
			FollowMouse();
		}
	}
	bool IsOnHold() {
		return (onHold);
	}
	void FollowMouse() {
		transform.position = CursorController.instance.GetPosition() + offsetMousePosition;
	}
	public void ViewBandage(bool isEnable) {
		if (!isEnable) {
			transform.position = new Vector2(-20,0);
		}
		onHold = isEnable;
		bandageImage.enabled = isEnable;
	}
}
