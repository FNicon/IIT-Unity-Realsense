using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronotPlayerController : MonoBehaviour {

	private Rigidbody2D clickedObj;
	private Vector2 offset;
	PhysicsMaterial2D tempMaterial;
	PhysicsMaterial2D storedMaterial;
	const float massDivider = 10f;
	public SFXManager batuSound;
	public bool isStillHolding;
	void Start () {
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
		CursorController.OnMouseHover += OnCursorHover;
		tempMaterial = new PhysicsMaterial2D();
		tempMaterial.bounciness = 0;
		tempMaterial.friction = 0;
	}
	
	void Update () {
		if(clickedObj != null){
			Vector2 secondOffset = CursorController.instance.GetPosition() - clickedObj.position;
			//clickedObj.position = CursorController.instance.GetPosition() + offset;
			Vector2 movePos = clickedObj.position + secondOffset + offset;
			if(clickedObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("bounceAnim"))
				clickedObj.transform.position = movePos;
			else
				clickedObj.MovePosition(movePos);
		}
	}

	public void OnCursorDown(){
		if (TimeManager.instance.isGameStart) {
			if(CursorController.instance.GetFirstClickedObj() != null){
				clickedObj = CursorController.instance.GetFirstClickedObj().GetComponent<Rigidbody2D>();
				clickedObj.velocity = Vector2.zero;
				clickedObj.angularVelocity = 0;
				clickedObj.mass /= massDivider;
				clickedObj.gameObject.layer = 8;
				clickedObj.gameObject.GetComponent<Animator>().SetTrigger("bounce");
				offset =  clickedObj.position - CursorController.instance.GetPosition();

				storedMaterial = clickedObj.sharedMaterial;
				clickedObj.sharedMaterial = tempMaterial;
				if(!isStillHolding) {
					isStillHolding = true;
					batuSound.PlayFromString("click");
				}
			}
		}
	}

	public void OnCursorUp(){
		if (storedMaterial == null) {
		} else if (clickedObj != null) {
			//Debug.Log(storedMaterial.name);
			clickedObj.gameObject.layer = 0;
			clickedObj.sharedMaterial = storedMaterial;
			clickedObj.velocity = new Vector2(Random.Range(-0.7f,0.7f), Random.Range(-0.7f,0.7f));
			clickedObj.angularVelocity = Random.Range(-0.7f,0.7f);
			clickedObj.mass *= massDivider;
			clickedObj = null;

			isStillHolding = false;
		}
	}

	public void OnCursorHover() {
		batuSound.PlayFromString("hover");
	}
}
