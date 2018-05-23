using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCounter : MonoBehaviour {
	public int leftAmount;

	// Use this for initialization
	void Start () {
		leftAmount = 6;
	}
	
	// Update is called once per frame
	void Update () {
		//leftAmount = GetComponentsInChildren<Transform>().Length - 1;
	}
	public void DecreaseAmount() {
		//leftAmount = leftAmount - 1;
		leftAmount = GetComponentsInChildren<Transform>().Length - 1;
		if (leftAmount <= 1) {
			AstronotGameManager.instance.GameOver();
		}
	}
}
