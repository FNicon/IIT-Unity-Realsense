using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGameManager : MonoBehaviour {
	public GameObject endPanel;
	public SFXManager soundEffects;
	void Awake () {
		TimeManager.Timesup += GameOver;
	}

	public void GameOver(){
		endPanel.SetActive(true);
		Animator anim = endPanel.GetComponentInChildren<Animator>();
		anim.SetInteger("STATE", ScoreManager.instance.GetNumberOfStar());
		soundEffects.PlayFromString(ScoreManager.instance.GetNumberOfStar().ToString());
		TimeManager.instance.PauseGame();
		//Time.timeScale = 0;
		Debug.Log("GAME OVER");
		Debug.Log("Star = " + ScoreManager.instance.GetNumberOfStar());
	}
}
