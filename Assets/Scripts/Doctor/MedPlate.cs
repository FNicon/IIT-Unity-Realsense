using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPlate : MonoBehaviour {
	private int minimalPhase = 0;
	public GameObject[] cottons;
	public GameObject[] bandages;
	public WoundManager woundManager;
	public Animator plateAnimation;
	// Use this for initialization
	void Start () {
		SetCotton();
		plateAnimation.SetBool("isShow",true);
	}
	
	// Update is called once per frame
	void Update () {
		if (woundManager.GetMinimalWoundPhase() == 1) {
			SetBandage();
		}
	}
	IEnumerator ChangePhase() {
		plateAnimation.SetBool("isShow",false);
		yield return new WaitForSeconds(1.5f);
		plateAnimation.SetBool("isShow",true);
		foreach (GameObject bandage in bandages) {
			bandage.SetActive(true);
		}
		foreach (GameObject cotton in cottons) {
			cotton.SetActive(false);
		}
	}
	void SetBandage() {
		StartCoroutine(ChangePhase());
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
