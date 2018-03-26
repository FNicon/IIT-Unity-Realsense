using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronotPlayerController : MonoBehaviour {

	private Rigidbody2D clickedObj;
	private Vector2 offset;
	PhysicsMaterial2D tempMaterial;
	PhysicsMaterial2D storedMaterial;
	const float massDivider = 10f;
	void Start () {
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
		tempMaterial = new PhysicsMaterial2D();
		tempMaterial.bounciness = 0;
		tempMaterial.friction = 0;
	}
	
	void Update () {
		if(clickedObj != null){
			Vector2 secondOffset = CursorController.instance.GetPosition() - clickedObj.position;
			//clickedObj.position = CursorController.instance.GetPosition() + offset;
			Vector2 movePos = clickedObj.position + secondOffset + offset;
			clickedObj.MovePosition(movePos);
		}
	}

	public void OnCursorDown(){
		if(CursorController.instance.GetFirstClickedObj() != null){
			clickedObj = CursorController.instance.GetFirstClickedObj().GetComponent<Rigidbody2D>();
			clickedObj.velocity = Vector2.zero;
			clickedObj.angularVelocity = 0;
			clickedObj.mass /= massDivider;
			offset =  clickedObj.position - CursorController.instance.GetPosition();

			storedMaterial = clickedObj.sharedMaterial;
			clickedObj.sharedMaterial = tempMaterial;
		}
	}

	public void OnCursorUp(){
		if (storedMaterial == null) {
		} else {
			//Debug.Log(storedMaterial.name);
			clickedObj.sharedMaterial = storedMaterial;
			clickedObj.velocity = new Vector2(Random.Range(-0.7f,0.7f), Random.Range(-0.7f,0.7f));
			clickedObj.angularVelocity = Random.Range(-0.7f,0.7f);
			clickedObj.mass *= massDivider;
			clickedObj = null;
		}
	}
}
