using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour {
	public GameObject[] fireObjects;
	[Range(0,10)]
	public int fireChance;
	public Vector2 minSpawnPoint;
	public Vector2 maxSpawnPoint;
	public float fireCooldown;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnFire());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator SpawnFire() {
		yield return new WaitForSeconds(fireCooldown);
		for (int i=0;i<fireObjects.Length;i++) {
			if (IsSpawnFire()) {
				GameObject fire = Instantiate(fireObjects[i],GenerateSpawnPoint(),this.transform.rotation);
				//Debug.Log("Fire");
			}
		}
		StartCoroutine(SpawnFire());
	}
	Vector3 GenerateSpawnPoint() {
		Vector3 spawnPoint;
		spawnPoint.x = Random.Range(minSpawnPoint.x,maxSpawnPoint.x);
		spawnPoint.y = Random.Range(minSpawnPoint.y,maxSpawnPoint.y);
		spawnPoint.z = 0;
		return (spawnPoint);
	}

	bool IsSpawnFire() {
		int randomNumber;
		randomNumber = Random.Range(0,10);
		return (randomNumber <= fireChance);
	}
}
