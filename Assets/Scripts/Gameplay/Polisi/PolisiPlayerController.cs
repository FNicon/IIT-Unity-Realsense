using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolisiPlayerController : MonoBehaviour {

	private GameObject clickedObj;
	private GameObject prevObj;
	public SFXManager ketangkapSound;

	void Start () {
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
	}
	
	void Update () {
		if(clickedObj != null){

		}
	}

	public void OnCursorDown(){
		if (TimeManager.instance.isGameStart) {
			if(CursorController.instance.GetFirstClickedObj() != null){
				clickedObj = CursorController.instance.GetFirstClickedObj();
				if (prevObj != clickedObj) {
					clickedObj.GetComponent<Animator>().SetBool("dead",true);
					ScoreManager.instance.AddScore();
					ketangkapSound.PlayFromString("ketangkap");
					prevObj = clickedObj;
				}
			}
		}
	}

	public void OnCursorUp(){

	}
	private void OnDestroy() {
		CursorController.OnMouseDown -= OnCursorDown;
		CursorController.OnMouseUp -= OnCursorUp;
	}
}
