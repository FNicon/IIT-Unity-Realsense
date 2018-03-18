using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotator : MonoBehaviour {

	[SerializeField]
	private RectTransform minuteHand;
	[SerializeField]
	private RectTransform hourHand; 

	void Awake () {
		
	}
	
	void Update () {
		float timeNorm = TimeManager.instance.GetTimeRemainingNormalized();
		minuteHand.rotation = Quaternion.Euler(0,0,-timeNorm*360);
		hourHand.rotation = Quaternion.Euler(0,0,-timeNorm*30);
	}
}
