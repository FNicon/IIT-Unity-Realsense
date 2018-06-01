using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorGameManager : MonoBehaviour {
	public GameObject endPanel;
	public SFXManager soundEffects;
	public AudioSource bgmSource;
	private bool once = false;
	void Awake () {
		once = false;
		TimeManager.Timesup += GameOver;
	}

	public void GameOver(){
		if (!once) {
			once = true;
			ScoreManager.instance.AddScore();
			endPanel.SetActive(true);
			Animator anim = endPanel.GetComponentInChildren<Animator>();
			anim.SetInteger("STATE", ScoreManager.instance.GetNumberOfStar());
			soundEffects.PlayFromString(ScoreManager.instance.GetNumberOfStar().ToString());
			TimeManager.instance.PauseGame();
			bgmSource.Stop();
			//Time.timeScale = 0;
			//Debug.Log("GAME OVER");
			//Debug.Log("Star = " + ScoreManager.instance.GetNumberOfStar());
		}
	}
	private void OnDestroy(){
		TimeManager.Timesup -= GameOver;
	}
}
