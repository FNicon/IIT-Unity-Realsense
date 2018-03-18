using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronotGameManager : MonoBehaviour {
	public static AstronotGameManager instance = null;
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
		Time.timeScale = 0;
		Debug.Log("GAME OVER");
		Debug.Log("Star = " + ScoreManager.instance.GetNumberOfStar());
	}
}
