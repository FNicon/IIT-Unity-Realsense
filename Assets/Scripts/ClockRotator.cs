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

	void Start () {
		startRotation_Hour = hourHand.rotation.eulerAngles.z;
		startRotation_Minute = hourHand.rotation.eulerAngles.z;
	}
	
	void Update () {
		float timeNorm = TimeManager.instance.GetTimeRemainingNormalized();
		minuteHand.rotation = Quaternion.Euler(0,0,-timeNorm*numberOfRotation*360);
		hourHand.rotation = Quaternion.Euler(0,0,startRotation_Hour+(-timeNorm*numberOfRotation*30));
	}
}
