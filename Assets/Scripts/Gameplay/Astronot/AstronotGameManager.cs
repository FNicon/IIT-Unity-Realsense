using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronotGameManager : MonoBehaviour {
	public static AstronotGameManager instance = null;
	public GameObject endPanel;
	public SFXManager soundEffects;
	// Use this for initialization
	void Awake () {
		if(instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		TimeManager.Timesup += GameOver;
	}

	public void GameOver(){
		endPanel.SetActive(true);
		Animator anim = endPanel.GetComponentInChildren<Animator>();
		anim.SetInteger("STATE", ScoreManager.instance.GetNumberOfStar());
		soundEffects.PlayFromString(ScoreManager.instance.GetNumberOfStar().ToString());
		Destroy(GameObject.FindGameObjectWithTag("batu"));
		TimeManager.instance.PauseGame();
		//Time.timeScale = 0;
		Debug.Log("GAME OVER");
		Debug.Log("Star = " + ScoreManager.instance.GetNumberOfStar());
	}
}
