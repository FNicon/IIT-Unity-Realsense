using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour {

	[SerializeField]
	private GameObject gameObjTag;

	string objTag;
	bool cursorClicking;
	GameObject objInTrigger;
	public SFXManager masukSound;
	public AsteroidCounter counter;
	private bool once = false;
	
	void Start () {
		objTag = gameObjTag.tag;
		CursorController.OnMouseDown += CursorClicked;
		CursorController.OnMouseUp += CursorUp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == objTag && cursorClicking && CursorController.instance.GetFirstClickedObj() == col.gameObject){
			transform.localScale = new Vector3(1.1f,1.1f);
			objInTrigger = col.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == objTag && cursorClicking && CursorController.instance.GetFirstClickedObj() == col.gameObject){
			transform.localScale = new Vector3(1.0f,1.0f);
			objInTrigger = null;
		}
	}

	private void OnTriggerStay2D(Collider2D col) {
		if(col.tag == objTag && cursorClicking && CursorController.instance.GetFirstClickedObj() == col.gameObject){
			transform.localScale = new Vector3(1.1f,1.1f);
			objInTrigger = col.gameObject;
		}
	}

	public void CursorClicked(){
		cursorClicking = true;
		once = false;
	}

	public void CursorUp(){
		if(objInTrigger != null){
			if (!once) {
				once = true;
				transform.localScale = new Vector3(1.0f,1.0f);
				Destroy(objInTrigger);
				ScoreManager.instance.AddScore();
				masukSound.PlayFromString("masuk");
				counter.DecreaseAmount();
			}
		}
		cursorClicking = false;
	}

	private void OnDestroy() {
		CursorController.OnMouseDown -= CursorClicked;
		CursorController.OnMouseUp -= CursorUp;
	}
}
