using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	public float scaleValue;
	public float countTime = 3;
	public float explodeTime;
	private Vector3 newScale;
	public float sign = 1;
	// Use this for initialization
	void Start () {
		newScale = transform.localScale;
		StartBurn();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.MoveTowards(transform.localScale,newScale,Time.deltaTime);
	}
	void StartBurn() {
		StartCoroutine(BurnUp());
		countTime = 0;
	}
	IEnumerator BurnUp() {
		yield return new WaitForSeconds(1f);
		countTime = countTime + sign;
		newScale = new Vector3(transform.localScale.x + sign * scaleValue,transform.localScale.y + sign * scaleValue, 1);
		if (countTime >= explodeTime) {
			Debug.Log("You Lose!");
			StopCoroutine(this.BurnUp());
		} else if (countTime <= 0) {
			StopBurn();
		} else {
			StartCoroutine(BurnUp());
		}
	}
	void StopBurn() {
		StopCoroutine(this.BurnUp());
		Destroy(this.gameObject);
		Debug.Log("AAAAAAAAAAa");
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			sign = -1;
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			sign = 1;
		}
	}
}
