using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawnPoint : MonoBehaviour {
	public bool isOnFire;
	private SpriteRenderer spawnPointRender;
	public Sprite spawnPointDanger;
	public Sprite spawnPointSafe;
	// Use this for initialization
	private void Awake() {
		spawnPointRender = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isOnFire) {
			spawnPointRender.sprite = spawnPointDanger;
		} else {
			spawnPointRender.sprite = spawnPointSafe;
		}
	}
}
