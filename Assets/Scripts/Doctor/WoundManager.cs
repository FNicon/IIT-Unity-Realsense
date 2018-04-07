using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundManager : MonoBehaviour {
	public int woundAmount;
	public Animator patientAnimation;
	private int curedWound = 0;
	private Wound[] wounds;
	private DoctorGameManager gameManager;
	private void Awake() {
		wounds = FindObjectsOfType<Wound>();
		gameManager = FindObjectOfType<DoctorGameManager>();
	}
	public void AddCuredWound() {
		curedWound = curedWound + 1;
		ScoreManager.instance.AddScore();
		isCuring();
	}
	public void isCuring() {
		StopCoroutine(this.Transition());
		patientAnimation.SetBool("isCuring",true);
		StartCoroutine(Transition());
	}
	IEnumerator Transition() {
		yield return new WaitForSeconds(1f);
		if (curedWound >= woundAmount) {
			patientAnimation.SetBool("isCured",true);
			gameManager.GameOver();
		} else {
			patientAnimation.SetBool("isCuring",false);
		}
	}
	public int GetMinimalWoundPhase() {
		int minimalWounds = wounds[0].CurrentPhase();
		for (int i = 1; i < wounds.Length; i++) {
			if (minimalWounds >= wounds[i].CurrentPhase()) {
				minimalWounds = wounds[i].CurrentPhase();
			}
		}
		return (minimalWounds);
	}
}
