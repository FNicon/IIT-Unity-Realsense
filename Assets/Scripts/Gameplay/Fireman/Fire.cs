using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	private FireGameManager gameManager;
	private FireFade fireFade;
	private FireSize fireSize;
	private bool isBurnUp;
	public float growDelay;
	public FireSpawnPoint spawnPoint;
	public SFXManager soundEffects;
	
	// Use this for initialization
	private void Awake() {
		gameManager = FindObjectOfType<FireGameManager>();
		fireFade = gameObject.GetComponent<FireFade>();
		fireSize = gameObject.GetComponent<FireSize>();
	}
	void Start () {
		StartBurn();
	}
	void StartBurn() {
		spawnPoint.isOnFire = true;
		isBurnUp = true;
		StartCoroutine(BurnUp());
	}

	void StopBurn() {
		isBurnUp = false;
		StopCoroutine(this.BurnDown());
		ScoreManager.instance.AddScore();
		spawnPoint.isOnFire = false;
		soundEffects.PlayFromString("apimati");
		Destroy(this.gameObject);
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("water") && isBurnUp) {
			isBurnUp = false;
			StopCoroutine(this.BurnUp());
			StartCoroutine(this.BurnDown());	
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("water") && !isBurnUp) {
			isBurnUp = true;
			StopCoroutine(this.BurnDown());
			StartCoroutine(this.BurnUp());
		}
	}
	public IEnumerator BurnUp() {
		yield return new WaitForSeconds(growDelay);
		if (isBurnUp) {
			fireSize.Grow();
			fireFade.FadeIn();
			if (fireSize.IsOnExplodePhase() && !fireSize.IsStillGrowing()) {
				gameManager.GameOver();
				StopCoroutine(this.BurnUp());
			} else {	
				StartCoroutine(BurnUp());
			}
		}
	}
	public IEnumerator BurnDown() {
		if (!isBurnUp) {
			fireSize.Shrink();
			if (fireSize.GetCurrentPhase() <= 1) {
				fireFade.FadeOut();
			}
			if (fireSize.IsOnZeroPhase() && !fireSize.IsStillShrinking()) {
				StopBurn();
			} else {
				yield return new WaitForSeconds(1f);
				StartCoroutine(BurnDown());
			}
		}
	}
}
