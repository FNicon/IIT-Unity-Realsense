using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolisiPlayerController : MonoBehaviour {

	private GameObject clickedObj;

	void Start () {
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
	}
	
	void Update () {
		if(clickedObj != null){

		}
	}

	public void OnCursorDown(){
		if(CursorController.instance.GetFirstClickedObj() != null){
			clickedObj = CursorController.instance.GetFirstClickedObj();
			clickedObj.GetComponent<Animator>().SetBool("dead",true);
			ScoreManager.instance.AddScore();
		}
	}

	public void OnCursorUp(){

	}
}
