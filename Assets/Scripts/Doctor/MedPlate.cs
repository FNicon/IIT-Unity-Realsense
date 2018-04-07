using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPlate : MonoBehaviour {
	private int minimalPhase = 0;
	public GameObject[] cottons;
	public GameObject[] bandages;
	public WoundManager woundManager;
	// Use this for initialization
	void Start () {
		SetCotton();
	}
	
	// Update is called once per frame
	void Update () {
		if (woundManager.GetMinimalWoundPhase() == 1) {
			SetBandage();
		}	
	}
	void SetBandage() {
		foreach (GameObject bandage in bandages) {
			bandage.SetActive(true);
		}
		foreach (GameObject cotton in cottons) {
			cotton.SetActive(false);
		}
	}
	void SetCotton() {
		foreach (GameObject bandage in bandages) {
			bandage.SetActive(false);
		}
		foreach (GameObject cotton in cottons) {
			cotton.SetActive(true);
		}
	}
}
