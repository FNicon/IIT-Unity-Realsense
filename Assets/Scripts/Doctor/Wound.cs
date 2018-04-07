using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour {
	private SpriteRenderer wound;
	public Sprite[] woundSprites;
	public string[] cureWounds;
	private int phaseCount;
	public WoundManager woundManager;
	
	// Use this for initialization
	void Start () {
		wound = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
	public bool IsCured() {
		return (phaseCount >= woundSprites.Length - 1);
	}
	public void NextPhase(string medInput) {
		if (!IsCured()) {
			if (cureWounds[phaseCount] == medInput) {
				phaseCount = phaseCount + 1;
				ViewPhase();
			}
		}
	}
	public int CurrentPhase() {
		return (phaseCount);
	}
	void ViewPhase() {
		wound.sprite = woundSprites[phaseCount];
		woundManager.isCuring();
		if (IsCured()) {
			woundManager.AddCuredWound();
		}
	}
}
