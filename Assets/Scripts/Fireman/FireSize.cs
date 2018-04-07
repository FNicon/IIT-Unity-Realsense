using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSize : MonoBehaviour {
	public Vector3[] scalePhases;
	public int countPhase;
	public float growTime;
	public Vector3 startSize;
	private Vector3 newSize;
	
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(startSize.x,startSize.y,startSize.z);
		newSize = new Vector3(startSize.x,startSize.y,startSize.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.MoveTowards(transform.localScale,newSize,Time.deltaTime * growTime);
	}
	public void Grow() {
		newSize = new Vector3(scalePhases[countPhase].x,scalePhases[countPhase].y,scalePhases[countPhase].z);
	}
	public void Shrink() {
		newSize = new Vector3(scalePhases[countPhase].x,scalePhases[countPhase].y,scalePhases[countPhase].z);
	}
	public void StopSizeChange() {
		newSize = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
	}
}
