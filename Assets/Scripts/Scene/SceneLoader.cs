using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public string sceneToLoad;
	private string currentScene;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ().name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextScene () {
		SceneManager.LoadScene (sceneToLoad);
	}
}
