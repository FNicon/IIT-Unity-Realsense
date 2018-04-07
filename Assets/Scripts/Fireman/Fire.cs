using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	private FireGameManager gameManager;
	public float growScale;
	public float shrinkScale;
	public float countTime = 3;
	public float explodeTime;
	public float growTime;
	public Vector3 startSize;
	private Vector3 newSize;
	private float sign = 1;
	public float growDelay;
	// Use this for initialization
	private void Awake()
	{
		gameManager = FindObjectOfType<FireGameManager>();
	}
	void Start () {
		transform.localScale = startSize;
		newSize = transform.localScale;
		StartBurn();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.MoveTowards(transform.localScale,newSize,Time.deltaTime * growTime);
	}
	void StartBurn() {
		StartCoroutine(BurnUp());
		countTime = 0;
	}
	IEnumerator BurnUp() {
		yield return new WaitForSeconds(growDelay);
		countTime = countTime + sign;
		newSize = new Vector3(transform.localScale.x + sign * growScale,transform.localScale.y + sign * growScale, 1);
		if (countTime >= explodeTime) {
			gameManager.GameOver();
			//Debug.Log("You Lose!");
			StopCoroutine(this.BurnUp());
		} else if (countTime <= 0) {
			StopBurn();
		} else {
			StartCoroutine(BurnUp());
		}
	}
	void StopBurn() {
		StopCoroutine(this.BurnUp());
		ScoreManager.instance.AddScore();
		Destroy(this.gameObject);
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			sign = -1 * shrinkScale;
			newSize = new Vector3(transform.localScale.x + sign * growScale,transform.localScale.y + sign * growScale, 1);
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			sign = 1;
		}
	}
}
