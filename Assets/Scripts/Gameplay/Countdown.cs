using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {
	Animator countdownAnimation;
	// Use this for initialization
	void Start () {
		countdownAnimation = GetComponent<Animator>();
		StartCoroutine(StartCountDown());
	}
	
	// Update is( called once per frame
	void Update () {
		
	}
	IEnumerator StartCountDown() {
		yield return new WaitUntil(()=>countdownAnimation.GetCurrentAnimatorStateInfo(0).IsName("Empty"));
		//Debug.Log("AAAAAA");
		TimeManager.instance.ResumeGame();
	}
}
