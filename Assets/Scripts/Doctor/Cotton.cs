﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cotton : MonoBehaviour {
	public bool isOnTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			isOnTrigger = true;
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			isOnTrigger = false;
		}
	}
}
