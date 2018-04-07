using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundManager : MonoBehaviour {
	public int woundAmount;
	public Animator patientAnimation;
	private int curedWound = 0;
	public void AddCuredWound() {
		curedWound = curedWound + 1;
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
		} else {
			patientAnimation.SetBool("isCuring",false);
		}
	}
}
