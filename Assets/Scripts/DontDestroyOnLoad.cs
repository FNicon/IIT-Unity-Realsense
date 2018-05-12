using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
	private static bool created = false;

	void Awake() {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
