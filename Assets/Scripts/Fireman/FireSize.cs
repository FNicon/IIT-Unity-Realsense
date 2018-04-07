using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSize : MonoBehaviour {
	private int countPhase = 1;
	private int explodePhase;
	public Vector3[] scalePhases;
	//public Vector3[] firePositions;
	public float growTime;
	public Vector3 startSize;
	private Vector3 newSize;
	//private Vector3 newPosition;
	private bool isChangingSize;
	// Use this for initialization
	void Start () {
		explodePhase = scalePhases.Length;
		transform.localScale = new Vector3(startSize.x,startSize.y,startSize.z);
		//newPosition = transform.position;
		newSize = new Vector3(startSize.x,startSize.y,startSize.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.MoveTowards(transform.localScale,newSize,Time.deltaTime * growTime);
		//transform.position = Vector3.MoveTowards(transform.position,newPosition,Time.deltaTime * growTime);
	}
	public bool IsOnExplodePhase() {
		return (countPhase >= explodePhase -1);
	}
	public int GetCurrentPhase() {
		return (countPhase);
	}
	public bool IsOnZeroPhase() {
		return (countPhase <= 0);
	}
	public bool IsStillGrowing() {
		return (transform.localScale.x < scalePhases[countPhase].x);
	}
	public bool IsStillShrinking() {
		return (transform.localScale.x > scalePhases[countPhase].x);
	}
	public void Grow() {
		if (!IsOnExplodePhase()) {
			if (!isChangingSize) {
				countPhase = countPhase + 1;
				isChangingSize = true;
				ChangeSize(countPhase);
			}
			if (!IsStillGrowing()) {
				isChangingSize = false;
			}
		}
	}
	public void Shrink() {
		if (!IsOnZeroPhase()) {
			if (!isChangingSize) {
				countPhase = countPhase - 1;
				isChangingSize = true;
				ChangeSize(countPhase);	
			}
			if (!IsStillShrinking()) {
				isChangingSize = false;
			}
		}
	}
	public void ChangeSize(int countPhase) {
		newSize = new Vector3(scalePhases[countPhase].x,scalePhases[countPhase].y,scalePhases[countPhase].z);
		/*newPosition = new Vector3(transform.position.x + firePositions[countPhase].x,
								transform.position.y + firePositions[countPhase].y,
								transform.position.z + firePositions[countPhase].z);*/
	}
	public void StopSizeChange() {
		newSize = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
	}
}
