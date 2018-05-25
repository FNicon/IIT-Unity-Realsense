using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterButton : MonoBehaviour {
	public string mouseTag;
	public bool isHover;
	Animator anim;
	// Use this for initialization
	void Start () {
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
		anim = GetComponent<Animator>();
		mouseTag = "Player";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag(mouseTag)) {
			isHover = true;
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag(mouseTag)) {
			isHover = false;
		}
	}
	public void OnCursorDown(){
		if (isHover) {
			StartCoroutine("PressedAnimation");
		}
	}

	public void OnCursorUp(){
		if (isHover) {
			
		}
	}

	IEnumerator PressedAnimation() {
		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Pressed")) {
			anim.SetTrigger("Pressed");
		}
		yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Pressed"));
		yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length + 2.5f);
		anim.SetTrigger("Normal");
	}
	private void OnDestroy() {
		CursorController.OnMouseDown -= OnCursorDown;
		CursorController.OnMouseUp -= OnCursorUp;
	}
}
