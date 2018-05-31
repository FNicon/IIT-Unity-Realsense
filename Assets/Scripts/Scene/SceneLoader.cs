using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public string sceneToLoad;
	public Animator transition;
	//private string currentScene;
	AsyncOperation operation;
	public bool once = false;
	public bool isLoadFromStart;
	// Use this for initialization
	void Start () {
		operation = null;
		if (isLoadFromStart && sceneToLoad != "") {
			StartCoroutine(AsyncLoad(sceneToLoad));
		}
		//currentScene = SceneManager.GetActiveScene().name;
		/*if (sceneToLoad != "") {
			StartCoroutine(AsyncLoad(sceneToLoad));
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if (operation != null) {
			//Debug.Log(operation.progress);
		}
	}

	IEnumerator WaitLoadScene(string scene) {
		yield return new WaitUntil(()=>transition.GetCurrentAnimatorStateInfo(0).IsName("Idle Full"));
		if (!isLoadFromStart) {
			StartCoroutine(AsyncLoad(scene));
		}
		operation.allowSceneActivation = true;
	}

	IEnumerator AsyncLoad(string scene) {
		operation = SceneManager.LoadSceneAsync(scene);
		operation.allowSceneActivation = false;
		while (!operation.isDone) {
			yield return null;
		}
		//yield return new WaitUntil(()=>operation.isDone);
		//Debug.Log(operation.progress);
	}

	public void nextScene () {
		if (!once) {
			once = true;
			transition.SetBool("isFadeIn",true);
			StartCoroutine(WaitLoadScene(sceneToLoad));
		}
	}
	public void loadSpecificScene(string inputScene) {
		if (!once) {
			once = true;
			transition.SetBool("isFadeIn",true);
			StartCoroutine(WaitLoadScene(inputScene));
		}
	}
	public void resetScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void loadCurrentScene() {
		if (!once) {
			once = true;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void ExitGame() {
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
