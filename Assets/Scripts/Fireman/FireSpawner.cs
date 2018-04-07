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
	public Transform[] spawnPoints;
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
			}
		}
		StartCoroutine(SpawnFire());
	}
	Vector3 GenerateSpawnPoint() {
		int choosenSpawnPoint = Random.Range(0,spawnPoints.Length);
		return (spawnPoints[choosenSpawnPoint].position);
	}

	bool IsSpawnFire() {
		int randomNumber;
		randomNumber = Random.Range(0,10);
		return (randomNumber <= fireChance);
	}
}
