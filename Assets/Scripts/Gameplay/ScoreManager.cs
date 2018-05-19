using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null;
	[SerializeField]
	private int scorePerStar;
	private int score;
	void Awake () {
		if(instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}
	
	public void AddScore(){
		score++;
	}

	public void AddScore(int n){
		score += n;
	}

	public void MinusScore(){
		score--;
	}

	public void MinusScore(int n){
		score -= n;
	}

	public int GetCurrentScore(){
		return score;
	} 

	public int GetNumberOfStar(){
		return score/scorePerStar;
	}
}
