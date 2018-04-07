using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cotton : MonoBehaviour {
	private SpriteRenderer cottonImage;
	public bool isOnTrigger;
	public Vector2 offsetMousePosition;
	// Use this for initialization
	private void Awake() {
		cottonImage = GetComponent<SpriteRenderer>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (IsOnHold()) {
			FollowMouse();
		}
	}
	bool IsOnHold() {
		return (cottonImage.enabled);
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
	public void ViewCotton(bool isEnable) {
		if (!isEnable) {
			transform.position = new Vector2(-20,0);
		}
		cottonImage.enabled = isEnable;
	}
}
