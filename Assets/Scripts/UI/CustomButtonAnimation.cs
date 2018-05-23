using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomButtonAnimation : MonoBehaviour {
	Animator animator;
	public string mouseTag;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		mouseTag = "Player";
		//mouseTag = FindObjectOfType<CursorController>().tag;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(mouseTag)) {
			animator.SetBool("Highlight",true);
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag(mouseTag)) {
			animator.SetBool("Highlight",false);
		}
	}
}
