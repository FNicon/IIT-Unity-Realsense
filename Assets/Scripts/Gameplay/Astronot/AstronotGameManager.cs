using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronotGameManager : MonoBehaviour {
	public static AstronotGameManager instance = null;
	public GameObject endPanel;
	public SFXManager soundEffects;
	public AudioSource bgmSource;
	private bool once = false;
	// Use this for initialization
	void Awake () {
		if(instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		once = false;
		TimeManager.Timesup += GameOver;
	}

	public void GameOver(){
		if (!once) {
			once = true;
			endPanel.SetActive(true);
			Animator anim = endPanel.GetComponentInChildren<Animator>();
			anim.SetInteger("STATE", ScoreManager.instance.GetNumberOfStar());
			//Debug.Log("AAAAAA" + ScoreManager.instance.GetNumberOfStar().ToString());
			soundEffects.PlayFromString(ScoreManager.instance.GetNumberOfStar().ToString());
			Destroy(GameObject.FindGameObjectWithTag("batu"));
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
