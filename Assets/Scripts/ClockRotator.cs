using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotator : MonoBehaviour {

	[SerializeField]
	private int numberOfRotation;
	[SerializeField]
	private RectTransform minuteHand;
	[SerializeField]
	private RectTransform hourHand; 

	private float startRotation_Minute;
	private float startRotation_Hour;
	bool gameOver = false;
	void Start () {
		startRotation_Hour = hourHand.rotation.eulerAngles.z;
		startRotation_Minute = hourHand.rotation.eulerAngles.z;
		TimeManager.Timesup += GameOver;
	}
	
	void Update () {
		if(gameOver)
			return;
			
		float timeNorm = TimeManager.instance.GetTimeRemainingNormalized();
		minuteHand.rotation = Quaternion.Euler(0,0,-timeNorm*numberOfRotation*360);
		hourHand.rotation = Quaternion.Euler(0,0,startRotation_Hour+(-timeNorm*numberOfRotation*30));
	}

	public void GameOver (){
		gameOver = true;
	}
}
