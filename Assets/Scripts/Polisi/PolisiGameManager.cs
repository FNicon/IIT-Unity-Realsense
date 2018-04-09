using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolisiGameManager : MonoBehaviour {
	public static PolisiGameManager instance = null;
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
		Destroy(GameObject.FindGameObjectWithTag("pencuri"));
		Time.timeScale = 0;
		Debug.Log("GAME OVER");
		Debug.Log("Star = " + ScoreManager.instance.GetNumberOfStar());
	}
}
