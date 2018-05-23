using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencuriSpawner : MonoBehaviour {
	[System.Serializable]
	struct SpawnInfo {
		public Vector3 pos;
		public Vector3 rotation;
		public string layerName;
		public int layerOrder;
	}
	public static PencuriSpawner instance = null;
	[SerializeField]
	private SpawnInfo[] spawn;
	[SerializeField]
	private GameObject pencuriObj;

	private int lastIdx;
	public SFXManager munculSound;
	public int maxSpawnCount;
	public int currentSpawnCount;
	// Use this for initialization
	void Awake () {
		currentSpawnCount = 0;
		if(instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}
	
	public void SpawnRandom() {
		if(currentSpawnCount < maxSpawnCount) {
			int idx = Random.Range(0, spawn.Length);
			GameObject target = Instantiate(pencuriObj, spawn[idx].pos, Quaternion.Euler(spawn[idx].rotation));
			target.GetComponentInChildren<SpriteRenderer>().sortingLayerName = spawn[idx].layerName;
			target.GetComponentInChildren<SpriteRenderer>().sortingOrder = spawn[idx].layerOrder;
			lastIdx = idx;
			munculSound.PlayFromString("muncul");
			currentSpawnCount = currentSpawnCount + 1;
		} else {
			PolisiGameManager.instance.GameOver();
		}
	}

	public void SpawnRandomExceptLast() {
		if(currentSpawnCount < maxSpawnCount) {
			int idx;
			if(lastIdx == 0){
				idx = Random.Range(1, spawn.Length);
			} else if(lastIdx == spawn.Length-1) {
				idx = Random.Range(0, spawn.Length-1);
			} else {
				int min = Random.Range(0, lastIdx);
				int max = Random.Range(lastIdx+1, spawn.Length);
				if(Random.Range(0,2) == 0)
					idx = min;
				else
					idx = max;
			}
			
			GameObject target = Instantiate(pencuriObj, spawn[idx].pos, Quaternion.Euler(spawn[idx].rotation));
			target.GetComponentInChildren<SpriteRenderer>().sortingLayerName = spawn[idx].layerName;
			target.GetComponentInChildren<SpriteRenderer>().sortingOrder = spawn[idx].layerOrder;
			lastIdx = idx;
			munculSound.PlayFromString("muncul");
			currentSpawnCount = currentSpawnCount + 1;
		} else {
			PolisiGameManager.instance.GameOver();
		}
	}
}
