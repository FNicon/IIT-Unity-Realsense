using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	private FireGameManager gameManager;
	public float countTime = 0;
	public float explodePhase;
	public float growDelay;
	private FireFade fireFade;
	private FireSize fireSize;
	private bool isBurnUp;
	
	// Use this for initialization
	private void Awake()
	{
		gameManager = FindObjectOfType<FireGameManager>();
		fireFade = gameObject.GetComponent<FireFade>();
		fireSize = gameObject.GetComponent<FireSize>();
	}
	void Start () {
		StartBurn();
	}
	void StartBurn() {
		isBurnUp = true;
		StartCoroutine(BurnUp());
		countTime = 0;
	}

	void StopBurn() {
		isBurnUp = false;
		StopCoroutine(this.BurnDown());
		ScoreManager.instance.AddScore();
		Destroy(this.gameObject);
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			isBurnUp = false;
			StopCoroutine(this.BurnUp());
			StartCoroutine(this.BurnDown());	
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			isBurnUp = true;
			fireFade.StopFade();
			fireSize.StopSizeChange();
			StopCoroutine(this.BurnDown());
			StartCoroutine(this.BurnUp());
		}
	}
	public IEnumerator BurnUp() {
		if (countTime >= explodePhase) {
			gameManager.GameOver();
			StopCoroutine(this.BurnUp());
		}
		yield return new WaitForSeconds(growDelay);
		if (isBurnUp) {
			countTime = countTime + 1;
			fireSize.Grow();
			fireFade.FadeIn();
			
			StartCoroutine(BurnUp());
		}
	}
	public IEnumerator BurnDown() {
		if (transform.localScale.x <= 0) {
			StopBurn();
		}
		if (!isBurnUp) {
			countTime = countTime - 1;
			fireFade.FadeOut();
			fireSize.Shrink();	
			yield return new WaitForSeconds(1f);
			StartCoroutine(BurnDown());
		}
	}
}
