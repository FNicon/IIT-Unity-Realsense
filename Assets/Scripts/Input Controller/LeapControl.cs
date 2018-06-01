using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class LeapControl : MonoBehaviour {
	private Controller controller;
	private Transform cursorTransform;
	private CursorController cursorController;
	private float xInv;
	private float yInv;
	public GameObject cursor;
	public float moveFactor;
	public bool inverseX;
	public bool inverseY;
	public CursorControllerArkeolog cursorArkeolog;
	// Use this for initialization
	void Start () {
		controller = new Controller();
		cursor = GameObject.Find("Cursor");
		cursorTransform = cursor.GetComponent<Transform>();
		cursorController = cursor.GetComponent<CursorController>();
		
		if(inverseX) {
			xInv = -1;
		} else {
			xInv = 1;
		}

		if(inverseY) {
			yInv = -1;
		} else {
			yInv = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("update controller");
		if(controller.IsConnected) {
			//Debug.Log("Controller Connected");
			Frame frame = controller.Frame();
			Frame previous = controller.Frame(1);

			if(frame.Hands.Count > 0 && previous.Hands.Count > 0) {
				//Debug.Log("I see hands");
				Hand curr = frame.Hands[0];
				Hand prev = previous.Hands[0];

				Vector2 currCursorPos = cursorTransform.position;
				Vector deltaHandPos = curr.PalmPosition - prev.PalmPosition;
				// Vector2 deltaCursorPos = new Vector2(deltaHandPos.x * xInv * moveFactor, deltaHandPos.z * yInv * moveFactor);
				Vector2 deltaCursorPos = new Vector2(curr.PalmVelocity.x * xInv * moveFactor, -curr.PalmVelocity.z * yInv * moveFactor);
				//Debug.Log("Delta X: " + deltaCursorPos.x);
				//Debug.Log("Delta Y: " + deltaCursorPos.y);
				Vector2 newCursorPos = currCursorPos + deltaCursorPos;

				if(cursorController.InsideScreen(newCursorPos)) {
					cursorTransform.position = currCursorPos + deltaCursorPos;
				}

				if(curr.GrabAngle > 3.00) {
					//Debug.Log("Hand is grabbing");
					CursorController.isHandClicked = true;
					if (cursorArkeolog != null) {
						cursorArkeolog.isHandClicked = true;
					}
				} else {
					//Debug.Log("Hand grab released");
					CursorController.isHandClicked = false;
					if (cursorArkeolog != null) {
						cursorArkeolog.isHandClicked = false;
					}
				}
				
			}
		}
	}

	void OnDestroy() {
		controller.StopConnection();
	}
}
