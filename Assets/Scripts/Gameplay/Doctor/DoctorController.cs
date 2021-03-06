﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorController : MonoBehaviour {
	public Cotton holdCotton;
	public Bandage holdBandage;
	private GameObject holdObject;
	private GameObject putObject;
	public CursorTransition transition;
	private bool isHolding;
	public SFXManager soundManager;
	public SFXManager soundBenarManager;
	private bool isPlayingSound = false;
	// Use this for initialization
	void Start () {
		holdBandage.ViewBandage(false);
		holdCotton.ViewCotton(false);
		CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
		CursorController.OnMouseHover += OnCursorHover;
	}
	
	// Update is called once per frame
	void Update () {

	}
	private void OnTriggerStay2D(Collider2D other) {
		if (other.GetComponent<Wound>()!=null) {
			putObject = other.gameObject;
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.GetComponent<Wound>()!=null) {
			putObject = null;
		}
	}
	IEnumerator Transition() {
		yield return new WaitUntil(() => transition.IsTransitionFinished());
		if (holdObject!= null) {
			if (holdObject.CompareTag("cotton")) {
				holdCotton.ViewCotton(isHolding);
			} else if (holdObject.CompareTag("bandage")) {
				holdBandage.ViewBandage(isHolding);
			}
			if (!isHolding) {
				holdObject = null;
			}
		}
		isPlayingSound = false;
	}
	void OnCursorDown() {
		if (TimeManager.instance.isGameStart) {
			transition.ChangeToClickSize();
			holdObject = CursorController.instance.GetFirstClickedObj();
			if (holdObject!= null) {
				holdObject.GetComponent<GrabbableObject>().ChangeToClickSize();
				isHolding = true;
				if (!isPlayingSound) {
					isPlayingSound = true;
					soundBenarManager.PlayFromString("click");
				}
				if (holdObject.CompareTag("cotton")) {
					holdCotton.SetOnHold(true);
				} else if (holdObject.CompareTag("bandage")) {
					holdCotton.SetOnHold(true);
				}
				StartCoroutine(Transition());
			}
		}
	}
	void OnCursorUp() {
		transition.ChangeToReleaseSize();
		if (holdObject!= null) {
			isHolding = false;
			if (holdObject.CompareTag("cotton")) {
				holdCotton.SetOnHold(false);
			} else if (holdObject.CompareTag("bandage")) {
				holdCotton.SetOnHold(false);
			}
			if (putObject!=null) {
				putObject.GetComponent<Wound>().NextPhase(holdObject.tag);
				/*if (!isPlayingSound) {
					isPlayingSound = true;
					soundBenarManager.PlayFromString("benar");
				}*/
			} else {
				if (!isPlayingSound) {
					isPlayingSound = true;
					soundBenarManager.PlayFromString("salah");
				}
			}
			StartCoroutine(Transition());
		}
	}
	void OnCursorHover() {
		soundManager.PlayFromString("hover");
	}

	private void OnDestroy() {
		CursorController.OnMouseDown -= OnCursorDown;
		CursorController.OnMouseUp -= OnCursorUp;
		CursorController.OnMouseHover -= OnCursorHover;
	}
}
