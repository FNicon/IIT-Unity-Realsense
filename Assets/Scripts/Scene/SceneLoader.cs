using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public string sceneToLoad;
	public Animator transition;
	private string currentScene;
	AsyncOperation operation;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator WaitLoadScene(string scene) {
		yield return new WaitUntil(()=>transition.GetCurrentAnimatorStateInfo(0).IsName("Idle Full"));
		StartCoroutine(AsyncLoad(scene));
		operation.allowSceneActivation = true;
	}

	IEnumerator AsyncLoad(string scene) {
		operation = SceneManager.LoadSceneAsync(scene);
		operation.allowSceneActivation = false;
		while (!operation.isDone) {
			yield return null;
		}
	}

	public void nextScene () {
		SceneManager.LoadScene(sceneToLoad);
	}
	public void loadSpecificScene(string inputScene) {
		transition.SetBool("isFadeIn",true);
		StartCoroutine(WaitLoadScene(inputScene));
		//SceneManager.LoadScene(inputScene);
	}

	public void ExitGame() {
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
