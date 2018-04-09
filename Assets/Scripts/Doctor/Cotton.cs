using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cotton : MonoBehaviour {
	private SpriteRenderer cottonImage;
	public Vector2 offsetMousePosition;
	private bool onHold;
	private Vector4 newColor;
	// Use this for initialization
	private void Awake() {
		cottonImage = GetComponent<SpriteRenderer>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (IsOnHold()) {
			newColor = new Vector4(cottonImage.color.r,cottonImage.color.g,cottonImage.color.b,255);
			FollowMouse();
		} else {
			newColor = new Vector4(cottonImage.color.r,cottonImage.color.g,cottonImage.color.b,0);
		}
		cottonImage.color = Vector4.MoveTowards(cottonImage.color,newColor,Time.deltaTime);
	}
	bool IsOnHold() {
		return (onHold);
	}
	public void SetOnHold(bool inputOnHold) {
		onHold = inputOnHold;
	}
	void FollowMouse() {
		transform.position = CursorController.instance.GetPosition() + offsetMousePosition;
	}
	public void ViewCotton(bool isEnable) {
		if (!isEnable) {	
			transform.position = new Vector2(-20,0);
		}
	}
}
