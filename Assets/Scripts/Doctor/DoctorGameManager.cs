using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorGameManager : MonoBehaviour {
	void Awake () {
		TimeManager.Timesup += GameOver;
	}

	public void GameOver(){
		Time.timeScale = 0;
		Debug.Log("GAME OVER");
		Debug.Log("Star = " + ScoreManager.instance.GetNumberOfStar());
	}
}
