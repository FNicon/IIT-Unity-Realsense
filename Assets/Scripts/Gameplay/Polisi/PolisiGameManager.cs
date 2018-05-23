using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolisiGameManager : MonoBehaviour {
	public static PolisiGameManager instance = null;
	public GameObject endPanel;
	public SFXManager soundEffects;
	// Use this for initialization
	void Awake () {
		if(instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		InitGame();
		TimeManager.Timesup += GameOver;
	}
	
	void InitGame () {
		PencuriSpawner.instance.SpawnRandom();
	}

	public void PencuriDead(){
		PencuriSpawner.instance.SpawnRandomExceptLast();
	}

	public void GameOver(){
		endPanel.SetActive(true);
		Animator anim = endPanel.GetComponentInChildren<Animator>();
		anim.SetInteger("STATE", ScoreManager.instance.GetNumberOfStar());
		soundEffects.PlayFromString(ScoreManager.instance.GetNumberOfStar().ToString());
		Destroy(GameObject.FindGameObjectWithTag("pencuri"));
		TimeManager.instance.PauseGame();
		//Time.timeScale = 0;
		Debug.Log("GAME OVER");
		Debug.Log("Star = " + ScoreManager.instance.GetNumberOfStar());
	}
}
