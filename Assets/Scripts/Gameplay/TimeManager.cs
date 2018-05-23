using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public static TimeManager instance = null;
	public delegate void TimeMonitor();
	public static event TimeMonitor Timesup;
	[SerializeField]
	private float time;
	public bool isGameStart;

	float timeCounter = 0;

	void Awake () {
		if(instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}
	
	void Update () {
		if (isGameStart) {
			timeCounter += Time.deltaTime;
			if(timeCounter >= time){
				OnTimesUp();
			}
		}
	}

	void OnTimesUp(){
		if(Timesup != null)
			Timesup();
	}

	public float GetTimeRemainingNormalized(){
		return ((timeCounter) * 1f / time);
	}

	public void ResumeGame() {
		isGameStart = true;
	}
}
