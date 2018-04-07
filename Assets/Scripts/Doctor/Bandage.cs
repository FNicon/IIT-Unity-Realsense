using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandage : MonoBehaviour {
	private SpriteRenderer bandageImage;
	public bool isOnTrigger;
	public Vector2 offsetMousePosition;
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
		return (bandageImage.enabled);
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("wound")) {
			isOnTrigger = true;
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("wound")) {
			isOnTrigger = false;
		}
	}
	void FollowMouse() {
		transform.position = CursorController.instance.GetPosition() + offsetMousePosition;
	}
	public void ViewBandage(bool isEnable) {
		if (!isEnable) {
			transform.position = new Vector2(-20,0);
		}
		bandageImage.enabled = isEnable;
	}
}
